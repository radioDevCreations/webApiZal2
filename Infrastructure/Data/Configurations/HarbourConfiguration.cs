using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configurations
{
    public class HarbourConfiguration : IEntityTypeConfiguration<Harbour>
    {
        public void Configure(EntityTypeBuilder<Harbour> builder) 
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(254);

            builder.Property(x => x.City)
                .IsRequired()
                .HasMaxLength(254);
        }
    }
}
