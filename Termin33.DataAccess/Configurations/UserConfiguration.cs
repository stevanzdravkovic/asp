using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Termin33.DataAccess.Entities;

namespace Termin33.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasAlternateKey(x => x.Username);
            builder.Property(x => x.Username).HasMaxLength(30);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.FirstName).IsRequired();
            builder.Property(x => x.Username).IsRequired();
            builder.HasMany(u => u.Orders).WithOne(o => o.User).HasForeignKey(o => o.UserId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
