using AutoMapper;
using HouseSaldoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.DTO
{
    public class ContractDTO: BaseDTO
    {
        public int BillNumber { get; set; }

        public static ContractDTO FromData(Contract contract)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Contract, ContractDTO>());
            var mapper = new Mapper(config);
            return mapper.Map<ContractDTO>(contract);
        }
    }
}
