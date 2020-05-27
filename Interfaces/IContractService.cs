using SaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Interfaces
{
    public interface IContractService
    {
        ContractViewModel GetContractById(string Id);
        IEnumerable<ContractViewModel> GetContracts();
        void CreateContract(ContractCreateRQ contractCreateRQ);
        ContractViewModel UpdateContract(string Id, ContractCreateRQ contractCreateRQ);
        void Delete(string Id);
    }
}
