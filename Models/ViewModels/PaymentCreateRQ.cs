using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class PaymentCreateRQ
    {
        [DefaultValue(0)]
        public decimal Value { get; set; }
    }
}
