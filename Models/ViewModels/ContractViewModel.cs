using Microsoft.CodeAnalysis.CSharp.Syntax;
using SladoLab.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class ContractViewModel
    {
        [DefaultValue(null)]
        public long Id { get; set; }

        [DefaultValue(0)]
        public int BillNumber { get; set; }

        [DefaultValue(typeof(DateTime), "")]
        public DateTime Date { get; set; }

        private ContractViewModel(Contract contract)
        {
            this.Id = contract.Id;
            this.BillNumber = contract.BillNumber;
            this.Date = contract.Date;
        }

        public static explicit operator ContractViewModel(Contract contract)
        {
            return new ContractViewModel(contract);
        }
    }
}
