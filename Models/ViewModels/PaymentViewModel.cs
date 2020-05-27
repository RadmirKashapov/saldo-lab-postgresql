using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class PaymentViewModel
    {
        [DefaultValue(null)]
        public long Id { get; set; }

        [DefaultValue(0)]
        public decimal Value { get; set; }

        public virtual int MonthEnumId
        {
            get
            {
                return (int)this.Month;
            }
            set
            {
                Month = (MonthEnum)value;
            }
        }

        [DefaultValue(MonthEnum.JANUARY)]
        public MonthEnum Month { get; set; }

        [DefaultValue(1970)]
        public int Year { get; set; }

        private PaymentViewModel(Payment payment)
        {
            Id = payment.Id;
            Value = payment.Value;
            Month = payment.Month;
            MonthEnumId = payment.MonthEnumId;
            Year = payment.Year;
        }

        public static explicit operator PaymentViewModel(Payment payment)
        {
            return new PaymentViewModel(payment);
        }
    }
}
