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
    public class ContractsController : Controller
    {
        private readonly IContractService _contractService;

        public ContractsController(IContractService contractService)
        {
            _contractService = contractService;
        }
        // GET: ContractsController
        [HttpGet]
        [Route("api/Contracts/Get")]
        public IEnumerable<ContractViewModel> Get()
        {
            return _contractService.GetContracts().Select(s => ContractViewModel.FromDTO(s));
        }

        [HttpPost]
        [Route("api/Contracts/Create")]
        public IActionResult Create([FromBody] ContractViewModel contractViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contractService.CreateContract(contractViewModel);
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
        [Route("api/Contracts/Details/{id}")]
        public IActionResult Details(string id)
        {
            try
            {
                var contract = _contractService.GetContractById(id);
                return new ObjectResult(contract);
            }
            catch (ValidationException ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        [Route("api/Contracts/Edit/{id}")]
        public IActionResult Edit([FromBody] ContractViewModel contractViewModel, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return new ObjectResult(_contractService.UpdateContract(id, contractViewModel));
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

        [HttpDelete]
        [Route("api/Contracts/Delete/{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                _contractService.Delete(id);
                return Ok();
            }
            catch (ValidationException ex)
            {
                return NotFound(ex);
            }
        }
    }
}
