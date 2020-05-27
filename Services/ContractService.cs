using SaldoLab.Infrastructure.Exceptions;
using SaldoLab.Interfaces;
using SaldoLab.Models.ViewModels;
using SladoLab.Interfaces;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace SaldoLab.Services
{
    public class ContractService : IContractService
    {
        IUnitOfWork Database { get; set; }

        public ContractService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ContractViewModel CreateContract(ContractCreateRQ contractCreateRQ)
        {
            var contract = new Contract()
            {
                BillNumber = contractCreateRQ.BillNumber
            };
        }

        public void Delete(string Id)
        {
            var charge = Database.Contracts.Get(long.Parse(Id)) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            Database.Contracts.Delete(long.Parse(Id));
            Database.Save();
        }

        public ContractViewModel GetContractById(string Id)
        {
            var contract = (ContractViewModel) Database.Contracts.Get(long.Parse(Id)) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            return contract;
        }

        public IEnumerable<ContractViewModel> GetContracts()
        {
            var charges = Database.Contracts.GetAll().Select(ch => (ContractViewModel)ch) ?? throw new ValidationException($"Contracts not found.", "");
            return charges;
        }

        public ContractViewModel UpdateContract(string Id, ContractCreateRQ contractCreateRQ)
        {
            var contract = Database.Contracts.Get(long.Parse(Id)) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            contract.BillNumber = contractCreateRQ.BillNumber;

            Database.Contracts.Update(contract);
            Database.Save();
            return (ContractViewModel)contract;
        }
    }
}
