using AutoMapper;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.DTO
{
    public class HouseDTO: BaseDTO
    {
        public int HouseNumber { get; set; }
        public ContractDTO Contract { get; set; }
        public IEnumerable<ChargeDTO> Charges { get; set; }

        public HouseDTO FromData(House house)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<House, HouseDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<HouseDTO>(house);
        }
    }
}
