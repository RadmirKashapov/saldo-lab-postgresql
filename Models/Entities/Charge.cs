using HouseSaldoLab.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.Entities
{
    public class Charge: BaseEntity
    {
        public decimal Value { get; set; }
        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public Saldo Saldo { get; set; }
        public Guid HouseId { get; set; }
        public House House { get; set; }

    }
}
