using Microsoft.VisualBasic.CompilerServices;
using SaldoLab.Infrastructure;
using SaldoLab.Infrastructure.Exceptions;
using SaldoLab.Interfaces;
using SaldoLab.Models.ViewModels;
using SladoLab.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Services
{
    public class PaymentService : IPaymentService
    {
        IUnitOfWork Database { get; set; }

        public PaymentService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreatePayment(string chargeId, PaymentCreateRQ paymentCreateRQ)
        {
            var charge = Database.Charges.Find(o => !o.IsPaymentCompleted && o.Id == long.Parse(chargeId)).First() ?? throw new ValidationException($"Charge was paid.", "");

            if(paymentCreateRQ.Value <= 0)
            {
                throw new ValidationException("There are no money", "");
            }

            SaldoUtils utils = new SaldoUtils.GetInstance();
        }

        public PaymentViewModel GetPaymentById(string Id)
        {
            var payment = (PaymentViewModel)Database.Payments.Get(long.Parse(Id)) ?? throw new ValidationException($"Payment with {Id} not found.", "");
            return payment;
        }

        public IEnumerable<PaymentViewModel> GetPayments()
        {
            var payments = Database.Payments.GetAll().Select(ch => (PaymentViewModel)ch) ?? throw new ValidationException($"Payments not found.", "");
            return payments;
        }
    }
}
