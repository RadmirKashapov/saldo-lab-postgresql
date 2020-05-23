using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SladoLab.Models.Entities;
using SladoLab.Models.Interfaces;

namespace SladoLab.Controllers
{
    public class ChargesController : Controller
    {
        private readonly IUnitOfWork _dataAccessProvider;

        public ChargesController(IUnitOfWork dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Charges/Get")]
        public IEnumerable<Charge> Get()
        {
            return _dataAccessProvider.Charges.GetAll();
        }

        [HttpPost]
        [Route("api/Charges/Create")]
        public void Create([FromBody] Charge charge)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                charge.Id = obj.ToString();
                _dataAccessProvider.Charges.Create(charge);
            }
        }

        [HttpGet]
        [Route("api/Charges/Details/{id}")]
        public Charge Details(string id)
        {
            return _dataAccessProvider.Charges.Get(id);
        }

        [HttpPut]
        [Route("api/Charges/Edit")]
        public void Edit([FromBody] Charge charge)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Charges.Update(charge);
            }
        }

        [HttpDelete]
        [Route("api/Charges/Delete/{id}")]
        public void DeleteConfirmed(string id)
        {
            _dataAccessProvider.Charges.Delete(id);
        }
    }
}
