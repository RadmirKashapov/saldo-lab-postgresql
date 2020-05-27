using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SaldoLab.Models.ViewModels
{
    public class HouseCreateRQ
    {
        [DefaultValue(0)]
        public int HouseNumber { get; set; }

        [DefaultValue(0)]
        public int Contract { get; set; }
    }
}
