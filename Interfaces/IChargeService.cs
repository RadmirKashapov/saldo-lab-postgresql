using SaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Interfaces
{
    public interface IChargeService
    {
        ChargeViewModel GetChargeById(string Id);
        IEnumerable<ChargeViewModel> GetCharges();
        ChargeViewModel CreateCharge(string Id, ChargeCreateRQ chargeCreateRQ);
        ChargeViewModel UpdateCharge(string Id, ChargeCreateRQ chargeCreateRQ);
        void Delete(string Id);
    }
}
