using crudNet.Models;
using Microsoft.EntityFrameworkCore;

namespace crudNet.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<ElectionResult> ElectionResults { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Candidate> Candidates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ElectionResult>()
            .HasKey(e => e.Id);

            modelBuilder.ApplyConfiguration(new ElectionResultConfiguration());
            modelBuilder.ApplyConfiguration(new LocationConfiguration());
            modelBuilder.ApplyConfiguration(new CandidateConfiguration());
            base.OnModelCreating(modelBuilder);

        }
    }
}
