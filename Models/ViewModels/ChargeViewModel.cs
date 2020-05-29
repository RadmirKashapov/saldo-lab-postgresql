using AutoMapper;
using HouseSaldoLab.Infrastructure;
using HouseSaldoLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.ViewModels
{
    public class ChargeViewModel
    {
        public string Id { get; set; }
        public decimal Value { get; set; }
        public MonthEnum Month { get; set; }
        public int Year { get; set; }

        public static ChargeViewModel FromDTO(ChargeDTO chargeDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ChargeDTO, ChargeViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<ChargeViewModel>(chargeDTO);
        }
    }
}
