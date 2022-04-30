using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Avesdo.Models;

namespace Avesdo.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<OrdPiz>()
                .HasOne(o => o.Order)
                .WithMany(op => op.OrdPizs)
                .HasForeignKey(f => f.OrderId);
            builder.Entity<OrdPiz>()
                .HasOne(p => p.Pizza)
                .WithMany(op => op.OrdPizs)
                .HasForeignKey(f => f.PizzaId);

            builder.Entity<PizTop>()
                .HasOne(p => p.Pizza)
                .WithMany(pt => pt.PizTops)
                .HasForeignKey(f => f.PizzaId);
            builder.Entity<PizTop>()
                .HasOne(t => t.Topping)
                .WithMany(pt => pt.PizTops)
                .HasForeignKey(f => f.ToppingId);
        }

        public DbSet<Pizzas> Pizzas { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Toppings> Toppings { get; set; }
        public DbSet<OrdPiz> OrdPizs { get; set; }
        public DbSet<PizTop> PizTops { get; set; }
    }
}
