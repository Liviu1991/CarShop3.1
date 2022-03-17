using System;
using System.Collections.Generic;
using System.Text;
using CarShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
