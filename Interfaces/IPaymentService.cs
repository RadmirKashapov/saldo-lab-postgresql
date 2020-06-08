using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Interfaces
{
    public interface IPaymentService
    {
        PaymentDTO GetPaymentById(string Id);
        IEnumerable<PaymentDTO> GetPayments();
        PaymentDTO CreatePayment(string chargeId, PaymentViewModel paymentViewModel);
    }
}
