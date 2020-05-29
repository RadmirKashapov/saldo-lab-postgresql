using HouseSaldoLab.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace HouseSaldoLab.Models.EntityBuilders
{
    public class SaldoMap
    {
        public SaldoMap(ModelBuilder entityBuilder)
        {
            entityBuilder.Entity<Saldo>().HasKey(t => t.Id);
            entityBuilder.Entity<Saldo>().Property(t => t.Month).IsRequired();
            entityBuilder.Entity<Saldo>().Property(t => t.Year).IsRequired();
            entityBuilder.Entity<Saldo>().Property(t => t.Value).IsRequired();
            entityBuilder.Entity<Saldo>().Property(t => t.AddedDate).IsRequired();
            entityBuilder.Entity<Saldo>().Property(t => t.ChargeId).IsRequired();
        }
    }
}
