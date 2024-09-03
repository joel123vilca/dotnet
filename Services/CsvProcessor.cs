using CsvHelper;
using crudNet.Models;
using crudNet.Interface;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using ElectionResultsApp.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

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
            using (var reader = new StreamReader(_csvFilePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ElectionResult>().ToList();

                foreach (var record in records.Chunk(1000))
                {
                    foreach (var rec in record)
                    {
                        var state = await _context.States.FirstOrDefaultAsync(s => s.CodEdo == rec.CodEdo)
                                    ?? new State { CodEdo = rec.CodEdo, Name = rec.Edo };
                        var municipality = await _context.Municipalities.FirstOrDefaultAsync(m => m.CodMun == rec.CodMun && m.CodEdo == rec.CodEdo)
                                    ?? new Municipality { CodMun = rec.CodMun, Name = rec.Mun, CodEdo = rec.CodEdo, State = state };
                        var parish = await _context.Parishes.FirstOrDefaultAsync(p => p.CodPar == rec.CodPar && p.CodMun == rec.CodMun)
                                    ?? new Parish { CodPar = rec.CodPar, Name = rec.Par, CodMun = rec.CodMun, Municipality = municipality };
                        var votingCenter = await _context.VotingCenters.FirstOrDefaultAsync(vc => vc.CentroCode == rec.Centro)
                                    ?? new VotingCenter { CentroCode = rec.Centro, Name = rec.Centro, CodPar = rec.CodPar, Parish = parish };
                        var votingTable = await _context.VotingTables.FirstOrDefaultAsync(vt => vt.CentroCode == rec.Centro && vt.Number == rec.Mesa)
                                    ?? new VotingTable { CentroCode = rec.Centro, Number = rec.Mesa, VotosValidos = rec.VotosValidos, VotosNulos = rec.VotosNulos, URL = rec.URL, VotingCenter = votingCenter };

                        _context.VotingTables.Add(votingTable);

                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "EG", Votes = rec.EG });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "NM", Votes = rec.NM });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "LM", Votes = rec.LM });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "JABE", Votes = rec.JABE });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "JOBR", Votes = rec.JOBR });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "AE", Votes = rec.AE });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "CF", Votes = rec.CF });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "DC", Votes = rec.DC });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "EM", Votes = rec.EM });
                        _context.CandidateVotes.Add(new CandidateVote { VotingTableId = votingTable.Id, CandidateCode = "BERA", Votes = rec.BERA });

                        await _context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
