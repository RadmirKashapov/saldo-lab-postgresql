using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.ViewModels;
using HouseSaldoLab.Repositories;
using HouseSaldoLab.Services;
using Microsoft.AspNetCore.Mvc;

namespace HouseSaldoLab.Controllers
{
    [RoutePrefix("home")]
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
    }
}
