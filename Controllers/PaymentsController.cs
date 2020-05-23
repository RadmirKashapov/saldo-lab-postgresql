using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;

namespace SladoLab.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly IUnitOfWork _dataAccessProvider;

        public PaymentsController(IUnitOfWork dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Payments/Get")]
        public IEnumerable<Payment> Get()
        {
            return _dataAccessProvider.Payments.GetAll();
        }

        [HttpPost]
        [Route("api/Payments/Create")]
        public void Create([FromBody] Payment payment)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                payment.Id = obj.ToString();
                _dataAccessProvider.Payments.Create(payment);
            }
        }

        [HttpGet]
        [Route("api/Payments/Details/{id}")]
        public Payment Details(string id)
        {
            return _dataAccessProvider.Payments.Get(id);
        }

        [HttpPut]
        [Route("api/Payments/Edit")]
        public void Edit([FromBody] Payment payment)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Payments.Update(payment);
            }
        }

        [HttpDelete]
        [Route("api/Payments/Delete/{id}")]
        public void DeleteConfirmed(string id)
        {
            _dataAccessProvider.Payments.Delete(id);
        }
    }
}
