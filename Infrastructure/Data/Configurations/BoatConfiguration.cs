using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class BoatConfiguration : IEntityTypeConfiguration<Boat>
    {
        public void Configure(EntityTypeBuilder<Boat> builder)
        {
            builder.Property(x => x.Brand)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(x => x.Type)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(x => x.Model)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(x => x.Year)
                .IsRequired();
        }
    }
}
