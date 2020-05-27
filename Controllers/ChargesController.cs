using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaldoLab.Models.ViewModels;
using SladoLab.Interfaces;
using SladoLab.Models.Entities;

namespace SladoLab.Controllers
{
    [Produces("application/json")]
    [Route("api/Charges")]
    public class ChargesController : Controller
    {
        private readonly IUnitOfWork _dataAccessProvider;

        public ChargesController(IUnitOfWork dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Charge> Get()
        {
            return _dataAccessProvider.Charges.GetAll();
        }

        [HttpPost]
        [Route("api/Charges/Create")]
        public async Task<IActionResult> Create([FromBody] ChargeViewModel chargeViewModel)
        {

            if (ModelState.IsValid)
            {
                var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<ChargeViewModel, Charge>()
                .ForMember(dest => dest.Payments, opts => opts.MapFrom(src => src.Payments))
                .ForMember(dest => dest.Saldo.Value, opts => opts.MapFrom(src => src.SaldoValue))
                .ForMember(dest => dest.House, opts => opts.MapFrom(src => src.House))
                .ForMember(dest => dest.HouseId, opts => opts.MapFrom(src => src.House.Id)));
                var mapper = new Mapper(mapperConfig);
                var charge = mapper.Map<ChargeViewModel, Charge>(chargeViewModel);

                _dataAccessProvider.Charges.Create(charge);
                return BadRequest(ModelState);
            } 
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Route("api/Charges/Details/{id}")]
        public Charge Details(long id)
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
        public void DeleteConfirmed(long id)
        {
            _dataAccessProvider.Charges.Delete(id);
        }
    }
}
