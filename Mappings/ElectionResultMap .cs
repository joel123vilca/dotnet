using crudNet.Models;
using CsvHelper.Configuration;

namespace crudNet.Mappings
{
    public sealed class ElectionResultMap : ClassMap<ElectionResult>
    {
        public ElectionResultMap()
        {
            Map(m => m.CodEdo).Name("COD_EDO");
            Map(m => m.Edo).Name("EDO");
            Map(m => m.CodMun).Name("COD_MUN");
            Map(m => m.Mun).Name("MUN");
            Map(m => m.CodPar).Name("COD_PAR");
            Map(m => m.Par).Name("PAR");
            Map(m => m.Centro).Name("CENTRO");
            Map(m => m.Mesa).Name("MESA");
            Map(m => m.VotosValidos).Name("VOTOS_VALIDOS");
            Map(m => m.VotosNulos).Name("VOTOS_NULOS");
            Map(m => m.EG).Name("EG");
            Map(m => m.NM).Name("NM");
            Map(m => m.LM).Name("LM");
            Map(m => m.JABE).Name("JABE");
            Map(m => m.JOBR).Name("JOBR");
            Map(m => m.AE).Name("AE");
            Map(m => m.CF).Name("CF");
            Map(m => m.DC).Name("DC");
            Map(m => m.EM).Name("EM");
            Map(m => m.BERA).Name("BERA");
            Map(m => m.URL).Name("URL");

            // Ignore Id
            Map(m => m.Id).Ignore();
        }
    }
}