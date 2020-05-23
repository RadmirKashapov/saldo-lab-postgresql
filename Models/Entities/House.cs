using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class House
    {
        public string Id { get; set; }
        public int HouseNumber { get; set; }
        public string ContractId { get; set; }
    }
}
