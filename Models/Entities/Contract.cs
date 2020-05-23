using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Contract
    {
        [Column(TypeName = "varchar(500)")]
        public string Id { get; set; }

        [Column(TypeName = "integer")]
        public int BillNumber { get; set; }

        public House House { get; set; }
    }
}
