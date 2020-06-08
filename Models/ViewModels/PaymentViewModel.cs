using AutoMapper;
using HouseSaldoLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.ViewModels
{
    public class PaymentViewModel
    {
        public Guid Id { get; set; }
        public decimal Value { get; set; }

        public static PaymentViewModel FromDTO(PaymentDTO PaymentDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PaymentDTO, PaymentViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<PaymentViewModel>(PaymentDTO);
        }
    }
}
