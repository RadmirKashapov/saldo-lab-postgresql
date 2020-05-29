using HouseSaldoLab.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.Entities
{
    public class Payment: BaseEntity
    {
        public decimal Value { get; set; }
        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public Guid ChargeId { get; set; }
        public Charge Charge { get; set; }
    }
}
