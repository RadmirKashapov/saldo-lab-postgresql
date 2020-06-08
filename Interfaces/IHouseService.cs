using HouseSaldoLab.Models.DTO;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Interfaces
{
    public interface IHouseService
    {
        HouseDTO GetHouseById(string Id);
        IEnumerable<HouseDTO> GetHouses();
        HouseDTO CreateHouse(HouseViewModel houseViewModel);
        HouseDTO updateHouse(string id, HouseViewModel houseViewModel);
    }
}
