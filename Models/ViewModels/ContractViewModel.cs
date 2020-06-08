using AutoMapper;
using HouseSaldoLab.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.ViewModels
{
    public class ContractViewModel
    {
        public Guid Id { get; set; }
        public int BillNumber { get; set; }

        public static ContractViewModel FromDTO(ContractDTO contractDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ContractDTO, ContractViewModel>());
            var mapper = new Mapper(config);
            return mapper.Map<ContractViewModel>(contractDTO);
        }
    }
}
