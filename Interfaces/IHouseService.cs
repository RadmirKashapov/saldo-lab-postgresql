using SaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Services
{
    public interface IHouseService
    {
        HouseViewModel GetHouseById(string Id);
        IEnumerable<HouseViewModel> GetHouses();
        void CreateHouse(HouseCreateRQ houseRq);
        HouseViewModel updateHouse(string id, HouseCreateRQ houseCreateRq);
    }
}
