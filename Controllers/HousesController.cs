using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HouseSaldoLab.Controllers
{
    public class HousesController : Controller
    {
        private readonly IHouseService _houseService;

        public HousesController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        [Route("api/Houses/Get")]
        public IEnumerable<HouseViewModel> Get()
        {
            return _houseService.GetHouses().Select(h => HouseViewModel.FromDTO(h));
        }

        [HttpPost]
        [Route("api/Houses/Create")]
        public IActionResult Create([FromBody] HouseViewModel houseViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _houseService.CreateHouse(houseViewModel);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("api/Houses/Details/{id}")]
        public IActionResult Details(string id)
        {
            try
            {
                return new ObjectResult(_houseService.GetHouseById(id));
            }
            catch (ValidationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("api/Houses/Edit/{id}")]
        public IActionResult Edit([FromBody] HouseViewModel houseViewModel, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return new ObjectResult(_houseService.updateHouse(id, houseViewModel));
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ValidationException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
