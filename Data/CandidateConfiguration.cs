using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using crudNet.Models;

namespace crudNet.Data
{
    public class CandidateConfiguration: IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c=> c.Name).IsRequired();
            builder.Property(c=> c.Abbrevation).IsRequired();
        }
    }
}
