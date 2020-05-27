using SaldoLab.Infrastructure.Exceptions;
using SaldoLab.Interfaces;
using SaldoLab.Models.ViewModels;
using SladoLab.Interfaces;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Services
{
    public class ChargeService : IChargeService
    {
        IUnitOfWork Database { get; set; }

        public ChargeService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public ChargeViewModel CreateCharge(string houseId, ChargeCreateRQ chargeCreateRQ)
        {
            var house = Database.Houses.Get(long.Parse(houseId)) ?? throw new ValidationException($"House with {houseId} not found.", "");

            var charge = new Charge() {
                Value = chargeCreateRQ.Value,
                Month = chargeCreateRQ.Month,
                Year = chargeCreateRQ.Year,
                House = house,
                HouseId = house.Id
            };
            Database.Charges.Create(charge);
            Database.Save();
            return GetChargeById(charge.Id.ToString());
        }

        public void Delete(string Id)
        {
            var charge = Database.Charges.Get(long.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");
            Database.Charges.Delete(long.Parse(Id));
            Database.Save();
        }

        public ChargeViewModel GetChargeById(string Id)
        {
            var charge = Database.Charges.Get(long.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");
            return (ChargeViewModel)charge;
        }

        public IEnumerable<ChargeViewModel> GetCharges()
        {
            var charges = Database.Charges.GetAll().Select(ch => (ChargeViewModel)ch) ?? throw new ValidationException($"Charges not found.", "");
            return charges;
        }

        public ChargeViewModel UpdateCharge(string Id, ChargeCreateRQ chargeCreateRQ)
        {
            var charge = Database.Charges.Get(long.Parse(Id)) ?? throw new ValidationException($"Charge with {Id} not found.", "");

            charge.Value = chargeCreateRQ.Value;
            charge.Month = chargeCreateRQ.Month;
            charge.Year = chargeCreateRQ.Year;

            Database.Charges.Update(charge);
            Database.Save();

            return GetChargeById(Id.ToString());
        }
    }
}
