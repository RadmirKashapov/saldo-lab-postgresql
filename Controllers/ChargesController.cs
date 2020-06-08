using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.ViewModels;
using HouseSaldoLab.Repositories;
using HouseSaldoLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseSaldoLab.Controllers
{
    public class ChargesController : Controller
    {
        private readonly IChargeService _chargeService;

        public ChargesController(IChargeService serv)
        {
            _chargeService = serv;
        }

        [HttpGet]
        [Route("api/charges/")]
        public IActionResult Index()
        {
            try
            {
                var charges = _chargeService.GetCharges().Select(s => ChargeViewModel.FromDTO(s));
                return View(charges);
            }
            catch (ValidationException ex)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("api/сharges/сreate/{id}")]
        public IActionResult Create(string id, [FromBody] ChargeViewModel chargeViewModel)
        {

            if (ModelState.IsValid)
            {
                var charge = _chargeService.CreateCharge(id, chargeViewModel);
                return RedirectToAction();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("api/Charges/Details/{id}")]
        public IActionResult Details(string id)
        {
            var item = _chargeService.GetChargeById(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

        [HttpPut]
        [Route("api/Charges/Edit/{id}")]
        public IActionResult Edit(string id, [FromBody] ChargeViewModel chargeViewModel)
        {
            if (ModelState.IsValid)
            {
                var charge = _chargeService.UpdateCharge(id, chargeViewModel);
                return new ObjectResult(charge);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("api/Charges/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _chargeService.Delete(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
