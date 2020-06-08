using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseSaldoLab.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        [Route("api/Payments/Get")]
        public IEnumerable<PaymentViewModel> Get()
        {
            return _paymentService.GetPayments().Select(p => PaymentViewModel.FromDTO(p));
        }

        [HttpPost]
        [Route("api/Payments/Create/{chargeId}")]
        public IActionResult Create([FromBody] PaymentViewModel paymentViewModel, string chargeId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _paymentService.CreatePayment(chargeId, paymentViewModel);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/Payments/Details/{id}")]
        public IActionResult Details(string id)
        {
            try
            {
                return new ObjectResult(_paymentService.GetPaymentById(id));
            }
            catch (ValidationException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
