using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using crudNet.Models;

namespace crudNet.Data
{
    public class LocationConfiguration: IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(l => l.Id);
            builder.Property(l => l.StateName).IsRequired();
            builder.Property(l => l.MunicipalityName).IsRequired();
            builder.Property(l => l.ParishName).IsRequired();
        }
    }
}
