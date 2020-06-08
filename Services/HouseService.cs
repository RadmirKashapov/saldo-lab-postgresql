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
    public class HouseService : IHouseService
    {
        private IUnitOfWork Database { get; set; }

        public HouseService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public HouseDTO CreateHouse(HouseViewModel houseViewModel)
        {
            var contract = Database.Contracts.Find(p => p.BillNumber == houseViewModel.Contract).First() ?? throw new ValidationException($"Contract with {houseViewModel.Contract} not found.", "");

            if (Database.Houses.Find(o => o.ContractId == contract.Id).First() != null)
                throw new ValidationException($"House with {houseViewModel.HouseNumber} already exist.", "");

            var guidObj = new Guid();

            var house = new House()
            {
                HouseNumber = houseViewModel.HouseNumber,
                Contract = contract,
                ContractId = contract.Id,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                Id = guidObj
            };

            Database.Houses.Create(house);
            Database.Save();

            return GetHouseById(guidObj.ToString());
        }

        public HouseDTO GetHouseById(string Id)
        {
            var house = HouseDTO.FromData(Database.Houses.Get(Guid.Parse(Id))) ?? throw new ValidationException($"House with {Id} not found.", "");
            return house;
        }

        public IEnumerable<HouseDTO> GetHouses()
        {
            var houses = Database.Houses.GetAll().Select(hs => HouseDTO.FromData(hs)) ?? throw new ValidationException($"Houses not found.", "");
            return houses;
        }

        public HouseDTO updateHouse(string id, HouseViewModel houseViewModel)
        {
            var contract = Database.Contracts.Find(p => p.BillNumber == houseViewModel.Contract).First() ?? throw new ValidationException($"Contract with {houseViewModel.Contract} not found.", "");
            var house = Database.Houses.Get(Guid.Parse(id)) ?? throw new ValidationException($"House with {id} not found.", "");

            house.Contract.BillNumber = houseViewModel.Contract;
            house.HouseNumber = houseViewModel.HouseNumber;
            house.ModifiedDate = DateTime.UtcNow;

            Database.Houses.Update(house);
            Database.Save();

            return HouseDTO.FromData(house);
        }
    }
}
