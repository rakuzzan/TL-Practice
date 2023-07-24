using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace DatabaseProvider.Configurations
{
    public class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.ToTable("Competition").HasKey(a => a.CompetitionId);

            builder.Property(a => a.Date).IsRequired();
            builder.Property(a => a.Title).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Venue).IsRequired().HasMaxLength(150);

        }
    }
}