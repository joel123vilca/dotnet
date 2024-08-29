using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using crudNet.Models;

namespace crudNet.Data
{
    public class ElectionResultConfiguration : IEntityTypeConfiguration<ElectionResult>
    {
        public void Configure(EntityTypeBuilder<ElectionResult> builder)
        {
            
            builder.Property(er => er.StateName).IsRequired();
            builder.Property(er => er.MunicipalityName).IsRequired();
            builder.Property(er => er.ParishName).IsRequired();
        }
    }
}
