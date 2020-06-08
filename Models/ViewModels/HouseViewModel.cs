using AutoMapper;
using HouseSaldoLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.ViewModels
{
    public class HouseViewModel
    {
        public Guid Id { get; set; }
        public int HouseNumber { get; set; }
        public int Contract { get; set; }

        public static HouseViewModel FromDTO(HouseDTO houseDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<HouseDTO, HouseViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<HouseViewModel>(houseDTO);
        }
    }
}
