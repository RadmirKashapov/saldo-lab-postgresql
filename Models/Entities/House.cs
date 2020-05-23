using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class House
    {
        [Column(TypeName = "varchar(500)")]
        public string Id { get; set; }

        [Column(TypeName = "integer")]
        public int HouseNumber { get; set; }

        [Column(TypeName = "varchar(500)")]
        public string ContractId { get; set; }

        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }

        public IEnumerable<Charge> Charges { get; set; }
    }
}
