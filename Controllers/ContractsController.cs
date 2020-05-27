using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SladoLab.Interfaces;
using SladoLab.Models.Entities;

namespace SladoLab.Controllers
{
    public class ContractsController : Controller
    {
        private readonly IUnitOfWork _dataAccessProvider;

        public ContractsController(IUnitOfWork dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Contracts/Get")]
        public IEnumerable<Contract> Get()
        {
            return _dataAccessProvider.Contracts.GetAll();
        }

        [HttpPost]
        [Route("api/Contracts/Create")]
        public void Create([FromBody] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Contracts.Create(contract);
            }
        }

        [HttpGet]
        [Route("api/Contracts/Details/{id}")]
        public Contract Details(long id)
        {
            return _dataAccessProvider.Contracts.Get(id);
        }

        [HttpPut]
        [Route("api/Contracts/Edit")]
        public void Edit([FromBody] Contract contract)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Contracts.Update(contract);
            }
        }

        [HttpDelete]
        [Route("api/Contracts/Delete/{id}")]
        public void DeleteConfirmed(long id)
        {
            _dataAccessProvider.Contracts.Delete(id);
        }
    }
}
