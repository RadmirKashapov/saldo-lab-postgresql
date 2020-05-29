using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.EntityBuilders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Saldo> Saldos { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Charge>()
                .HasMany(u => u.Payments)
                .WithOne(p => p.Charge)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(p => p.ChargeId);

            modelBuilder
                .Entity<Charge>()
                .HasOne(u => u.Saldo)
                .WithOne(p => p.Charge)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<Saldo>(p => p.ChargeId);

            modelBuilder
                .Entity<Contract>()
                .HasOne(u => u.House)
                .WithOne(p => p.Contract)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey<House>(p => p.ContractId);

            modelBuilder
                .Entity<House>()
                .HasMany(u => u.Charges)
                .WithOne(p => p.House)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(p => p.HouseId);

            modelBuilder
                .Entity<Payment>()
                .HasOne(u => u.Charge)
                .WithMany(p => p.Payments)
                .HasForeignKey(u => u.ChargeId);

            modelBuilder
                .Entity<Saldo>()
                .HasOne(u => u.Charge)
                .WithOne(p => p.Saldo)
                .HasForeignKey<Saldo>(u => u.ChargeId);

            base.OnModelCreating(modelBuilder);

        }
    }
}
