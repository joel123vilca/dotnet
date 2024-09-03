using Microsoft.EntityFrameworkCore;
using ElectionResultsApp.Models;

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
            modelBuilder.Entity<State>()
                .HasIndex(s => s.CodEdo);

            modelBuilder.Entity<Municipality>()
                .HasIndex(m => new { m.CodEdo, m.CodMun });

            modelBuilder.Entity<Parish>()
                .HasIndex(p => new { p.CodPar });

            modelBuilder.Entity<VotingCenter>()
                .HasIndex(vc => vc.CentroCode);

            modelBuilder.Entity<VotingTable>()
                .HasIndex(vt => new { vt.CentroCode, vt.Number });

            modelBuilder.Entity<CandidateVote>()
                .HasIndex(cv => new { cv.VotingTableId, cv.CandidateCode });

            // Configuración de relaciones
            modelBuilder.Entity<Municipality>()
                .HasOne(m => m.State)
                .WithMany(s => s.Municipalities)
                .HasForeignKey(m => m.CodEdo)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Parish>()
                .HasOne(p => p.Municipality)
                .WithMany(m => m.Parishes)
                .HasForeignKey(p => p.MunicipalityId) // Usa 'MunicipalityId' en lugar de 'CodMun'
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VotingCenter>()
                .HasOne(vc => vc.Parish)
                .WithMany(p => p.VotingCenters)
                .HasForeignKey(vc => vc.ParishId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VotingTable>()
                .HasOne(vt => vt.VotingCenter)
                .WithMany(vc => vc.VotingTables)
                .HasForeignKey(vt => vt.VotingCenterId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CandidateVote>()
                .HasOne(cv => cv.VotingTable)
                .WithMany(vt => vt.CandidateVotes)
                .HasForeignKey(cv => cv.VotingTableId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
