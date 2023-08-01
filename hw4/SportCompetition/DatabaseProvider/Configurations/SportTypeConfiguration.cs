using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Xml.Linq;

namespace DatabaseProvider.Configurations
{
    public class SportTypeConfiguration : IEntityTypeConfiguration<SportType>
    {
        public void Configure(EntityTypeBuilder<SportType> builder)
        {
            builder.ToTable("SportType").HasKey(a => a.SportTypeId);

            builder.Property(a => a.Title).IsRequired().HasMaxLength(50);
            builder.Property(a => a.UnitOfMeasurment).IsRequired().HasMaxLength(20);
        }
    }
}