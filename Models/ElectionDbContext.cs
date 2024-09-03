using ElectionResultsApp.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;

namespace crudNet.Models
{

    public class ElectionDbContext : DbContext
    {
        public ElectionDbContext(DbContextOptions<ElectionDbContext> options) : base(options) { }

        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Parish> Parishes { get; set; }
        public DbSet<VotingCenter> VotingCenters { get; set; }
        public DbSet<VotingTable> VotingTables { get; set; }
        public DbSet<CandidateVote> CandidateVotes { get; set; }
        public DbSet<ElectionResult> ElectionResults { get; set; } // Se mantiene para mantener compatibilidad con la estructura inicial

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>().HasIndex(s => s.CodEdo);
            modelBuilder.Entity<Municipality>().HasIndex(m => new { m.CodEdo, m.CodMun });
            modelBuilder.Entity<Parish>().HasIndex(p => new { p.CodMun, p.CodPar });
            modelBuilder.Entity<VotingCenter>().HasIndex(vc => vc.CentroCode);
            modelBuilder.Entity<VotingTable>().HasIndex(vt => vt.CentroCode);
            modelBuilder.Entity<CandidateVote>().HasIndex(cv => new { cv.VotingTableId, cv.CandidateCode });
        }
    }
}
