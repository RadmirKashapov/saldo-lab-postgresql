using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouseSaldoLab.Models.Entities
{
    public class House: BaseEntity
    {
        public int HouseNumber { get; set; }
        public Guid ContractId { get; set; }
        public Contract Contract { get; set; }
        public ICollection<Charge> Charges { get; set; }
    }
}
