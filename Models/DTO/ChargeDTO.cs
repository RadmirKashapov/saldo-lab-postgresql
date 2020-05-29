using AutoMapper;
using HouseSaldoLab.Infrastructure;
using HouseSaldoLab.Models.Entities;
using HouseSaldoLab.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.DTO
{
    public class ChargeDTO: BaseDTO
    {
        public decimal Value { get; set; }
        public MonthEnum Month { get; set; }
        public int Year { get; set; }
        public bool IsPaymentCompleted { get; set; }
        public IEnumerable<PaymentViewModel> Payments { get; set; }
        public decimal SaldoValue { get; set; }
        public HouseDTO House { get; set; }
        public Guid HouseId { get; set; }


        public static ChargeDTO FromData(Charge charge)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Charge, ChargeDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ChargeDTO>(charge);
        }
    }
}
