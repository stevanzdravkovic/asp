using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Termin33.DataAccess.Configurations;
using Termin33.DataAccess.Entities;

namespace Termin33.DataAccess
{
    public class Termin33Context : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var groups = new List<Group>
            {
                new Group
                {
                    Id = 1,
                    Name = "Prva"
                },
                new Group
                {
                    Id = 2,
                    Name = "Druga"
                },
                new Group
                {
                    Id = 3,
                    Name = "Treca"
                },
            };

            modelBuilder.Entity<Group>().HasData(groups);
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());

            modelBuilder.Entity<Group>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<User>().HasQueryFilter(p => !p.IsDeleted);

            modelBuilder.Entity<OrderProduct>().HasKey(x => new { x.OrderId, x.ProductId });

        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch(entry.State)
                    {
                        case EntityState.Added:
                            e.IsActive = true;
                            e.CreatedAt = DateTime.Now;
                            e.IsDeleted = false;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            break;

                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.Now;
                            break;
                    }
                }
            }
            
            return base.SaveChanges();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\SQLEXPRESS;Initial Catalog=asp-primer;Integrated Security=True");
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
