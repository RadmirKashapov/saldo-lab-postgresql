using HouseSaldoLab.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.EntityBuilders
{
    public class ContractMap
    {
        public ContractMap(ModelBuilder entityBuilder)
        {
            entityBuilder.Entity<Contract>().HasKey(t => t.Id);
            entityBuilder.Entity<Contract>().HasIndex(t => t.BillNumber).IsUnique();
            entityBuilder.Entity<Contract>().Property(t => t.AddedDate).IsRequired();
        }
    }
}
