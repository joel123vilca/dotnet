using CsvHelper;
using crudNet.Models;
using crudNet.Interface;
using crudNet.Mappings;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ElectionResultsApp.Models;
using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration;

namespace crudNet.Services
{
    public class CsvProcessor : ICsvProcessor
    {
        private readonly ElectionDbContext _context;
        private readonly string _csvFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "DataFiles", "election_results.csv");

        public CsvProcessor(ElectionDbContext context)
        {
            _context = context;
        }

        public async Task ProcessCsvAsync()
        {
            if (!File.Exists(_csvFilePath))
            {
                throw new FileNotFoundException("El archivo CSV no se encontró.", _csvFilePath);
            }

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = true,
                HeaderValidated = null,  // Desactiva la validación de encabezados
                MissingFieldFound = null // Desactiva la validación de campos faltantes
            };

            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<ElectionResultMap>();

                var records = csv.GetRecords<ElectionResult>().ToList();

                foreach (var record in records.Chunk(100))
                {
                    foreach (var rec in record)
                    {
                        // Manejar Estado
                        var state = await _context.States.FirstOrDefaultAsync(s => s.CodEdo == rec.CodEdo)
                                    ?? new State { CodEdo = rec.CodEdo, Name = rec.Edo };

                        if (state.Id == 0)
                        {
                            _context.States.Add(state);
                            await _context.SaveChangesAsync();
                        }

                        // Manejar Municipio
                        var municipality = await _context.Municipalities
                            .Include(m => m.State)  // Carga la entidad relacionada
                            .FirstOrDefaultAsync(m => m.CodMun == rec.CodMun && m.State.CodEdo == rec.CodEdo)
                                    ?? new Municipality { CodMun = rec.CodMun, Name = rec.Mun, State = state };

                        if (municipality.Id == 0)
                        {
                            _context.Municipalities.Add(municipality);
                            await _context.SaveChangesAsync();
                        }

                        // Manejar Parroquia
                        var parish = await _context.Parishes
                            .Include(p => p.Municipality)  // Carga la entidad relacionada
                            .FirstOrDefaultAsync(p => p.CodPar == rec.CodPar && p.Municipality.CodMun == rec.CodMun)
                                    ?? new Parish { CodPar = rec.CodPar, Name = rec.Par, Municipality = municipality };

                        if (parish.Id == 0)
                        {
                            _context.Parishes.Add(parish);
                            await _context.SaveChangesAsync();
                        }

                        // Manejar Centro de Votación
                        var votingCenter = await _context.VotingCenters
                            .Include(vc => vc.Parish)  // Carga la entidad relacionada
                            .FirstOrDefaultAsync(vc => vc.CentroCode == rec.Centro)
                                    ?? new VotingCenter { CentroCode = rec.Centro, Name = rec.Centro, Parish = parish };

                        if (votingCenter.Id == 0)
                        {
                            _context.VotingCenters.Add(votingCenter);
                            await _context.SaveChangesAsync();
                        }

                        // Manejar Mesa de Votación
                        var votingTable = await _context.VotingTables
                            .Include(vt => vt.VotingCenter)  // Carga la entidad relacionada
                            .FirstOrDefaultAsync(vt => vt.VotingCenter.CentroCode == rec.Centro && vt.Number == rec.Mesa);

                        if (votingTable == null)
                        {
                            votingTable = new VotingTable { CentroCode = rec.Centro, Number = rec.Mesa, VotosValidos = rec.VotosValidos, VotosNulos = rec.VotosNulos, URL = rec.URL, VotingCenter = votingCenter };
                            _context.VotingTables.Add(votingTable);
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            votingTable.VotosValidos = rec.VotosValidos;
                            votingTable.VotosNulos = rec.VotosNulos;
                            votingTable.URL = rec.URL;
                            _context.VotingTables.Update(votingTable);
                            await _context.SaveChangesAsync();
                        }

                        // Manejar Votos de Candidatos
                        var candidateVotes = new List<CandidateVote>
                        {
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "EG", Votes = rec.EG },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "NM", Votes = rec.NM },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "LM", Votes = rec.LM },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "JABE", Votes = rec.JABE },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "JOBR", Votes = rec.JOBR },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "AE", Votes = rec.AE },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "CF", Votes = rec.CF },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "DC", Votes = rec.DC },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "EM", Votes = rec.EM },
                            new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "BERA", Votes = rec.BERA }
                        };

                        _context.CandidateVotes.AddRange(candidateVotes);

                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
