using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SladoLab.Models.Entities;
using SladoLab.Interfaces;

namespace SladoLab.Controllers
{
    public class HousesController : Controller
    {
        private readonly IUnitOfWork _dataAccessProvider;

        public HousesController(IUnitOfWork dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("api/Houses/Get")]
        public IEnumerable<House> Get()
        {
            return _dataAccessProvider.Houses.GetAll();
        }

        [HttpPost]
        [Route("api/Houses/Create")]
        public void Create([FromBody] House house)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Houses.Create(house);
            }
        }

        [HttpGet]
        [Route("api/Houses/Details/{id}")]
        public House Details(long id)
        {
            return _dataAccessProvider.Houses.Get(id);
        }

        [HttpPut]
        [Route("api/Houses/Edit")]
        public void Edit([FromBody] House house)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.Houses.Update(house);
            }
        }

        [HttpDelete]
        [Route("api/Houses/Delete/{id}")]
        public void DeleteConfirmed(long id)
        {
            _dataAccessProvider.Houses.Delete(id);
        }
    }
}
