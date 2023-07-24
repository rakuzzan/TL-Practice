using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace DatabaseProvider.Configurations
{
    public class PerformanceConfiguration : IEntityTypeConfiguration<Performance>
    {
        public void Configure(EntityTypeBuilder<Performance> builder)
        {
            builder.ToTable("Performance").HasKey(a => a.PerformanceId);

            builder.Property(a => a.Value).IsRequired();

            builder.HasOne(a => a.Sportsman).WithMany().HasForeignKey(a => a.SportsmanId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Competition).WithMany().HasForeignKey(a => a.CompetitionId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.SportType).WithMany().HasForeignKey(a => a.SportTypeId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}