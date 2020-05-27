using SaldoLab.Infrastructure.Exceptions;
using SaldoLab.Models.ViewModels;
using SladoLab.Interfaces;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Services
{
    public class HouseService : IHouseService
    {
        IUnitOfWork Database { get; set; }

        public HouseService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void CreateHouse(HouseCreateRQ houseRq)
        {
            var contract = Database.Contracts.Get(houseRq.Contract) ?? throw new ValidationException($"Contract with {houseRq.Contract} not found.", "");
            
            if(Database.Houses.Find(o => o.HouseNumber == houseRq.HouseNumber) != null)
                throw new ValidationException($"House with {houseRq.HouseNumber} already exist.", "");
            
            var house = new House()
            {
                HouseNumber = houseRq.HouseNumber,
                Contract = contract,
                ContractId = contract.Id
            };

            Database.Houses.Create(house);
            Database.Save();
        }

        public HouseViewModel GetHouseById(string Id)
        {
            var house = (HouseViewModel)Database.Houses.Get(long.Parse(Id)) ?? throw new ValidationException($"House with {Id} not found.", "");
            return house;
        }

        public IEnumerable<HouseViewModel> GetHouses()
        {
            var houses = Database.Houses.GetAll().Select(hs => (HouseViewModel)hs) ?? throw new ValidationException($"Houses not found.", "");
            return houses;
        }

        public HouseViewModel updateHouse(string id, HouseCreateRQ houseCreateRq)
        {
            var contract = Database.Contracts.Get(houseCreateRq.Contract) ?? throw new ValidationException($"Contract with {houseCreateRq.Contract} not found.", "");
            var house = Database.Houses.Get(long.Parse(id)) ?? throw new ValidationException($"House with {id} not found.", "");

            house.Contract.BillNumber = houseCreateRq.Contract;
            house.HouseNumber = houseCreateRq.HouseNumber;

            Database.Houses.Update(house);
            Database.Save();

            return (HouseViewModel)house;
        }
    }
}
