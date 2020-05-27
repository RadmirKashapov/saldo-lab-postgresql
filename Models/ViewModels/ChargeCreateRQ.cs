using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class ChargeCreateRQ
    {
        [DefaultValue(0)]
        public decimal Value { get; set; } 

        [DefaultValue(MonthEnum.JANUARY)]
        public MonthEnum Month { get; set; } 

        [DefaultValue(1970)]
        public int Year { get; set; }
    }
}
