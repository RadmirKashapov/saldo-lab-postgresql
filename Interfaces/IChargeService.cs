using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Interfaces
{
    public interface IChargeService
    {
        ChargeDTO GetChargeById(string houseId);
        IEnumerable<ChargeDTO> GetCharges();
        ChargeDTO CreateCharge(string Id, ChargeViewModel chargeViewModel);
        ChargeDTO UpdateCharge(string Id, ChargeViewModel chargeViewModel);
        void Delete(string Id);
    }
}
