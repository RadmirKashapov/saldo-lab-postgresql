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
            throw new NotImplementedException();
        }

        public PaymentViewModel GetPaymentById(string Id)
        {
            var payment = (PaymentViewModel)Database.Payments.Get(long.Parse(Id)) ?? throw new ValidationException($"Payment with {Id} not found.", "");
            return payment;
        }

        public IEnumerable<PaymentViewModel> GetPayments()
        {
            var charges = Database.Charges.GetAll().Select(ch => (ChargeViewModel)ch) ?? throw new ValidationException($"Charges not found.", "");
            return charges;
        }
    }
}
