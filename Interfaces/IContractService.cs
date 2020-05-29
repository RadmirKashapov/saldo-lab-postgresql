using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Interfaces
{
    public interface IContractService
    {
        ContractDTO GetContractById(string Id);
        IEnumerable<ContractDTO> GetContracts();
        ContractDTO CreateContract(ContractViewModel contractViewModel);
        ContractDTO UpdateContract(string Id, ContractViewModel contractViewModel);
        void Delete(string Id);
    }
}
