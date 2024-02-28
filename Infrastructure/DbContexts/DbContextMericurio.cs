﻿using Domain.Entities;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DbContexts
{
    public class DbContextMericurio:DbContext
    {
        public DbContextMericurio(DbContextOptions<DbContextMericurio> options) : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceItem> ServiceItem { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceItemConfiguration());
            
        }

    }
}