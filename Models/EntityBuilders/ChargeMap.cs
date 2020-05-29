using HouseSaldoLab.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.EntityBuilders
{
    public class ChargeMap
    {
        public ChargeMap(ModelBuilder entityBuilder)
        {
            entityBuilder.Entity<Charge>().HasKey(t => t.Id);
            entityBuilder.Entity<Charge>().Property(t => t.Month).IsRequired();
            entityBuilder.Entity<Charge>().Property(t => t.Year).IsRequired();
            entityBuilder.Entity<Charge>().Property(t => t.IsCompleted).IsRequired();
            entityBuilder.Entity<Charge>().Property(t => t.Value).IsRequired();
            entityBuilder.Entity<Charge>().Property(t => t.HouseId).IsRequired();
            entityBuilder.Entity<Charge>().Property(t => t.AddedDate).IsRequired();
        }
    }
}
