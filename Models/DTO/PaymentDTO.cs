using AutoMapper;
using HouseSaldoLab.Infrastructure;
using HouseSaldoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.DTO
{
    public class PaymentDTO: BaseDTO
    {
        public decimal Value { get; set; }
        public MonthEnum Month { get; set; }
        public Guid ChargeId { get; set; }
        public int Year { get; set; }

        public static PaymentDTO FromData(Payment payment)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Payment, PaymentDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<PaymentDTO>(payment);
        }
    }
}
