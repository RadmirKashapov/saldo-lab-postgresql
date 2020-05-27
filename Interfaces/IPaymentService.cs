using SaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Interfaces
{
    public interface IPaymentService
    {
        PaymentViewModel GetPaymentById(string Id);
        IEnumerable<PaymentViewModel> GetPayments();
        PaymentViewModel CreatePayment(string chargeId, PaymentCreateRQ paymentCreateRQ);
    }
}
