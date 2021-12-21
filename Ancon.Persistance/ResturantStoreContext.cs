﻿using Ancon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancon.Persistance
{
    public class ResturantStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Resturant> Resturants { get; set; }


        public ResturantStoreContext(DbContextOptions<ResturantStoreContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resturant>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.HasMany<Product>(r => r.Products)
                .WithOne(p => p.Resturant)
                .HasForeignKey(p => p.ResturantId);
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(pc => pc.Id);
                entity.HasMany<Product>(pc => pc.Products)
                .WithOne(p => p.ProductCategory)
                .HasForeignKey(p => p.ProductCategoryId);
            });
        }
    }
}
