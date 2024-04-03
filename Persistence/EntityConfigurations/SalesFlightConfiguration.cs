using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;


public class SalesFlightConfiguration : IEntityTypeConfiguration<SalesFlight>
{
    public void Configure(EntityTypeBuilder<SalesFlight> builder)
    {
        builder.ToTable("FlightSales").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CustomerName).HasColumnName("CustomerName").IsRequired().HasMaxLength(100);
        builder.Property(b => b.PassportNumber).HasColumnName("PassportNumber").IsRequired();
        builder.Property(b => b.CountryId).HasColumnName("CountryId").IsRequired();
        builder.Property(b => b.CityId).HasColumnName("CityId").IsRequired();
        builder.Property(b => b.FlightId).HasColumnName("FlightId").IsRequired();
        builder.Property(b => b.SalesDate).HasColumnName("SalesDate").IsRequired();

        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.PassportNumber, name: "UK_passport_number").IsUnique();



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
       
      


    }
}