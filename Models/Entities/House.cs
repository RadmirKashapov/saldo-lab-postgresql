using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class House
    {
        public long Id { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "integer")]
        public int HouseNumber { get; set; }

        [Column(TypeName = "bigint")]
        public long ContractId { get; set; }

        [DefaultValue(null)]
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }

        [DefaultValue(null)]
        public IEnumerable<Charge> Charges { get; set; }
    }
}
