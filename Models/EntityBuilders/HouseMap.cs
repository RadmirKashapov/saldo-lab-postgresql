using HouseSaldoLab.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseSaldoLab.Models.EntityBuilders
{
    public class HouseMap
    {
        public HouseMap(ModelBuilder entityBuilder)
        {
            entityBuilder.Entity<House>().HasKey(t => t.Id);
            entityBuilder.Entity<House>().Property(t => t.HouseNumber).IsRequired();
            entityBuilder.Entity<House>().Property(t => t.AddedDate).IsRequired();
            entityBuilder.Entity<House>().Property(t => t.ContractId).IsRequired();
        }
    }
}
