using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.Entities
{
    public class Contract: BaseEntity
    {
        public int BillNumber { get; set; }
        public House House { get; set; }
    }
}
