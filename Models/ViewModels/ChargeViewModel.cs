using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class ChargeViewModel
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

        [DefaultValue(false)]
        public bool IsPaymentCompleted { get; set; }

        [DefaultValue(null)]
        public IEnumerable<PaymentViewModel> Payments { get; set; }

        [DefaultValue(0)]
        public decimal SaldoValue { get; set; }

        [DefaultValue(null)]
        public HouseViewModel House { get; set; }

        public ChargeViewModel(Charge charge)
        {
            this.Id = charge.Id;
            this.Value = charge.Value;
            this.Month = charge.Month;
            this.Year = charge.Year;
            this.IsPaymentCompleted = charge.IsPaymentCompleted;
            this.Payments = charge.Payments.Select(p => (PaymentViewModel)p);
            this.House = (HouseViewModel)charge.House;
            this.SaldoValue = charge.Saldo.Value;
        }

        public static explicit operator ChargeViewModel(Charge charge)
        {
            return new ChargeViewModel(charge);
        }
    }
}
