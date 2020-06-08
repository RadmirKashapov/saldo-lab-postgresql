using HouseSaldoLab.Infrastructure;
using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Services
{
    public class PaymentService : IPaymentService
    {
        private IUnitOfWork Database { get; set; }

        public PaymentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public PaymentDTO CreatePayment(string chargeId, PaymentViewModel paymentViewModel)
        {
            var charge = Database.Charges.Find(o => !o.IsCompleted && o.Id == Guid.Parse(chargeId)).First() ?? throw new ValidationException($"Charge was paid.", "");

            if (paymentViewModel.Value <= 0)
            {
                throw new ValidationException("There are no money", "");
            }

            var currentDate = DateTime.Now;
            var utils = SaldoUtils.GetInstance();

            var previousDate = utils.GetPreviousDate(currentDate.Year, currentDate.Month - 1);
            var previousMonth = previousDate.Item2;
            var previousYear = previousDate.Item1;

            var saldo = Database.Saldos.Find(s => s.Month == previousMonth && s.Year == previousYear && s.Charge == charge).First();

            decimal newSaldoValue = 0;

            if (saldo == null)
            {
                newSaldoValue = charge.Value;
            }
            else
            {
                newSaldoValue = charge.Value + saldo.Value;
            }

            decimal valueByAllPayments = Database.Payments.Find(p => p.Charge == charge).Sum(o => o.Value);

            if (paymentViewModel.Value + valueByAllPayments >= newSaldoValue)
            {
                charge.IsCompleted = true;
                charge.ModifiedDate = DateTime.UtcNow;
                Database.Charges.Update(charge);
                Database.Save();
            }

            var guidObj = new Guid();

            var payment = new Payment()
            {
                Value = paymentViewModel.Value,
                Month = (MonthEnum)currentDate.Month,
                Year = currentDate.Year,
                Charge = charge,
                ChargeId = charge.Id,
                Id = guidObj,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };

            Database.Payments.Create(payment);
            Database.Save();

            return PaymentDTO.FromData(payment);
        }

        public PaymentDTO GetPaymentById(string Id)
        {
            var payment = PaymentDTO.FromData(Database.Payments.Get(Guid.Parse(Id))) ?? throw new ValidationException($"Payment with {Id} not found.", "");
            return payment;
        }

        public IEnumerable<PaymentDTO> GetPayments()
        {
            var payments = Database.Payments.GetAll().Select(ch => PaymentDTO.FromData(ch)) ?? throw new ValidationException($"Payments not found.", "");
            return payments;
        }
    }
}
