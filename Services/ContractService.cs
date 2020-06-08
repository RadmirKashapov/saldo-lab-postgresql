using HouseSaldoLab.Infrastructure.Exceptions;
using HouseSaldoLab.Interfaces;
using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Services
{
    public class ContractService: IContractService
    {
        private IUnitOfWork Database { get; set; }

        public ContractService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public ContractDTO CreateContract(ContractViewModel contractViewModel)
        {
            Guid guid = Guid.NewGuid();
            var contract = new Contract()
            {
                Id = guid,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                BillNumber = contractViewModel.BillNumber
            };

            Database.Contracts.Create(contract);
            Database.Save();
            return GetContractById(guid.ToString());
        }

        public void Delete(string Id)
        {
            var charge = Database.Contracts.Get(Guid.Parse(Id)) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            Database.Contracts.Delete(Guid.Parse(Id));
            Database.Save();
        }

        public ContractDTO GetContractById(string Id)
        {
            var contract = ContractDTO.FromData(Database.Contracts.Get(Guid.Parse(Id))) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            return contract;
        }

        public IEnumerable<ContractDTO> GetContracts()
        {
            var charges = Database.Contracts.GetAll().Select(ch => ContractDTO.FromData(ch)) ?? throw new ValidationException($"Contracts not found.", "");
            return charges;
        }

        public ContractDTO UpdateContract(string Id, ContractViewModel contractCreateRQ)
        {
            var contract = Database.Contracts.Get(Guid.Parse(Id)) ?? throw new ValidationException($"Contract with {Id} not found.", "");
            contract.BillNumber = contractCreateRQ.BillNumber;

            Database.Contracts.Update(contract);
            Database.Save();
            return ContractDTO.FromData(contract);
        }
    }
}
