using HouseSaldoLab.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HouseSaldoLab.Models.EntityBuilders
{
    public class PaymentMap
    {
        public PaymentMap(ModelBuilder entityBuilder)
        {
            entityBuilder.Entity<Payment>().HasKey(t => t.Id);
            entityBuilder.Entity<Payment>().Property(t => t.Month).IsRequired();
            entityBuilder.Entity<Payment>().Property(t => t.Year).IsRequired();
            entityBuilder.Entity<Payment>().Property(t => t.Value).IsRequired();
            entityBuilder.Entity<Payment>().Property(t => t.AddedDate).IsRequired();
            entityBuilder.Entity<Payment>().Property(t => t.ChargeId).IsRequired();
        }
    }
}
