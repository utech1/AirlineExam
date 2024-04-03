using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;


public class AirPortConfiguration : IEntityTypeConfiguration<AirPort>
{
    public void Configure(EntityTypeBuilder<AirPort> builder)
    {
        builder.ToTable("AirPort").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        builder.Property(b => b.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(b => b.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_airport_Name").IsUnique();



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);

      

    }
}