using Microsoft.EntityFrameworkCore;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Saldo> Saldos { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("ApplicationContext");
        }
    }
}
