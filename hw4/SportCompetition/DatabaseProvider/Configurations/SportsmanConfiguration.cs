using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace DatabaseProvider.Configurations
{
    public class SportsmanConfiguration : IEntityTypeConfiguration<Sportsman>
    {
        public void Configure(EntityTypeBuilder<Sportsman> builder)
        {
            builder.ToTable("Sportsman").HasKey(a => a.SportsmanId);

            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);

            builder.HasOne(a => a.Coach).WithMany().HasForeignKey(a => a.CoachId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}