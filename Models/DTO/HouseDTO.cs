using AutoMapper;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.DTO
{
    public class HouseDTO: BaseDTO
    {
        public int HouseNumber { get; set; }
        public ContractDTO Contract { get; set; }
        public IEnumerable<ChargeDTO> Charges { get; set; }

        public static HouseDTO FromData(House house)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<House, HouseDTO>()
            .ForMember((dest => dest.Charges), opt => opt.MapFrom(src => src.Charges.Select(s => ChargeDTO.FromData(s)))));
            var mapper = new Mapper(config);
            return mapper.Map<HouseDTO>(house);
        }
    }
}
