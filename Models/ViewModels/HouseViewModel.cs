using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class HouseViewModel
    {
        private HouseViewModel(House house)
        {
            Id = house.Id;
            HouseNumber = house.HouseNumber;
            Contract = (ContractViewModel)house.Contract;
            Charges = house.Charges.Select(ch => (ChargeViewModel)ch);
        }

        [DefaultValue(null)]
        public long Id { get; set; }

        [DefaultValue(0)]
        public int HouseNumber { get; set; }

        [DefaultValue(null)]
        public ContractViewModel Contract { get; set; }

        [DefaultValue(null)]
        public IEnumerable<ChargeViewModel> Charges { get; set; }

        public static explicit operator HouseViewModel(House house)
        {
            return new HouseViewModel(house);
        }
    }
}
