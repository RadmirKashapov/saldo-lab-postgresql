using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class ContractCreateRQ
    {
        [DefaultValue(0)]
        public int BillNumber { get; set; }
    }
}
