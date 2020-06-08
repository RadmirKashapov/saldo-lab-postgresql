using HouseSaldoLab.Infrastructure;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Services
{
    public class SaldoService
    {
        private IUnitOfWork Database { get; set; }

        public SaldoService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CalculateSaldoForAllCharges()
        {
            var utils = SaldoUtils.GetInstance();

            var currentDate = DateTime.Now;
            var currentMonth = currentDate.Month - 1;
            var currentYear = currentDate.Year;

            var previousDate = utils.GetPreviousDate(currentYear, currentMonth);
            var previousMonth = previousDate.Item2;
            var previousYear = previousDate.Item1;

            var allChargesPerMonth = Database.Charges.Find(ch => ch.Month == (MonthEnum)currentMonth && ch.Year == currentYear);

            foreach (var charge in allChargesPerMonth)
            {
                var currentSaldo = Database.Saldos.Find(s => s.Month == (MonthEnum)currentMonth && s.Year == currentYear && s.Charge == charge).First();

                if (currentSaldo != null)
                {
                    continue;
                }

                decimal valueByAllPayments = Database.Payments.Find(p => p.Charge == charge).Sum(o => o.Value);

                var previousSaldo = Database.Saldos.Find(s => s.Month == (MonthEnum)previousMonth && s.Year == previousYear && s.Charge == charge).First();

                decimal shouldToPay;

                if (previousSaldo == null)
                {
                    shouldToPay = charge.Value;
                }
                else
                {
                    shouldToPay = charge.Value + previousSaldo.Value;
                }

                var guidObj = new Guid();

                var saldo = new Saldo()
                {
                    Value = shouldToPay - valueByAllPayments,
                    Year = currentYear,
                    Month = (MonthEnum)currentMonth,
                    Charge = charge,
                    ChargeId = charge.Id,
                    AddedDate = currentDate,
                    ModifiedDate = currentDate,
                    Id = guidObj
                };
                Database.Saldos.Create(saldo);
                Database.Save();
            }

        }
    }
}
