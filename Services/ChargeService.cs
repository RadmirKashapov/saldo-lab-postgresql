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
    public class ChargeService : IChargeService
    {
        private IUnitOfWork Database { get; set; }

        public ChargeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public ChargeDTO CreateCharge(string houseId, ChargeViewModel chargeViewModel)
        {
            var house = Database.Houses.Get(Guid.Parse(houseId)) ?? throw new ValidationException($"Charge with {houseId} not found.", "");

            var guidObj = new Guid();
            var charge = new Charge()
            {
                Id = guidObj,
                Value = chargeViewModel.Value,
                Month = chargeViewModel.Month,
                Year = chargeViewModel.Year,
                AddedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                House = house,
                HouseId = house.Id,
                IsCompleted = false,
                Payments = null,
                Saldo = null
            };

            Database.Charges.Create(charge);
            Database.Save();

            return ChargeDTO.FromData(charge);
        }

        public void Delete(string Id)
        {
            var charge = Database.Charges.Get(Guid.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");

            Database.Charges.Delete(Guid.Parse(Id));
            Database.Save();
        }

        public ChargeDTO GetChargeById(string Id)
        {
            var charge = Database.Charges.Get(Guid.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");
            return ChargeDTO.FromData(charge);
        }

        public IEnumerable<ChargeDTO> GetCharges()
        {
            var charges = Database.Charges.GetAll();
            
            if (charges == null)
            {
                throw new ValidationException("Charges not found", "");
            }

            return charges.Select(ch => ChargeDTO.FromData(ch));
        }

        public ChargeDTO UpdateCharge(string Id, ChargeViewModel chargeViewModel)
        {
            var charge = Database.Charges.Get(Guid.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");

            charge.Value = chargeViewModel.Value;
            charge.Month = chargeViewModel.Month;
            charge.Year = chargeViewModel.Year;
            charge.ModifiedDate = DateTime.UtcNow;
            Database.Charges.Update(charge);
            Database.Save();

            return GetChargeById(Id.ToString());
        }
    }
}
