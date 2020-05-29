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
    }
}
