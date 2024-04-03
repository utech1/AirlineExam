using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;


public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Country").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.LongName).HasColumnName("LongName").IsRequired().HasMaxLength(100);
        builder.Property(b => b.ShortName).HasColumnName("ShortName").HasMaxLength(50);
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.LongName, name: "UK_long_Name").IsUnique();

     


        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        
    }
}