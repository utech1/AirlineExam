using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations;


public class FlighttConfiguration : IEntityTypeConfiguration<Flight>
{
    public void Configure(EntityTypeBuilder<Flight> builder)
    {
        builder.ToTable("Flight").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.FlightName).HasColumnName("FlightName").IsRequired().HasMaxLength(100);
        builder.Property(b => b.FromAirPortId).HasColumnName("FromAirPortId").IsRequired();
        builder.Property(b => b.ToAirPortId).HasColumnName("ToAirPortId").IsRequired();
        builder.Property(b => b.FlightCode).HasColumnName("FlightCode").IsRequired();
        builder.Property(b => b.FlightDate).HasColumnName("FlightDate").IsRequired();
        builder.Property(b => b.Status).HasColumnName("Status").IsRequired();

        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.FlightCode, name: "UK_Flight_Code").IsUnique();



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
       
      


    }
}