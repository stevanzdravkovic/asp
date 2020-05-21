using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Termin33.DataAccess.Entities;

namespace Termin33.DataAccess.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasMany(x => x.OrderProducts)
                   .WithOne(op => op.Order)
                   .HasForeignKey(op => op.OrderId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
