using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Saldo
    {
        public string Id { get; set; }
        public decimal Value { get; set; }
        public int Year { get; set; }
        public DateTime Date { get; set; }
        public MonthEnum Month { get; set; }

    }
}
