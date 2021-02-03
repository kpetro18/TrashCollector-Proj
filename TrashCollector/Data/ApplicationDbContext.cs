using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TrashCollector.Models;

namespace TrashCollector.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       public DbSet<Customer> Customers { get; set; }
       public DbSet<Employee> employees { get; set; }

        public DbSet<Day> Days { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>()
                .HasData(
                    new IdentityRole
                    {
                        Name = "Admin",
                        NormalizedName = "ADMIN"
                    }
                );

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                }
             );

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                }
             );

            builder.Entity<Day>()
                .HasData(
                new Day
                {
                    Id = 0,
                    Name = "Sunday"
                }, new Day
                {
                    Id = 1,
                    Name = "Monday"
                }, new Day
                {
                    Id = 2,
                    Name = "Tuesday"
                }, new Day
                {
                    Id = 3,
                    Name = "Wednesday"
                }, new Day
                {
                    Id = 4,
                    Name = "Thursday"
                }, new Day
                {
                    Id = 5,
                    Name = "Friday"
                }, new Day
                {
                    Id = 5,
                    Name = "Saturday"
                });
        }
    }
}
