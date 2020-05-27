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
    public class Contract
    {
        public long Id { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "integer")]
        public int BillNumber { get; set; }

        [DefaultValue(typeof(DateTime))]
        [Column(TypeName = "timestamp")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

        [DefaultValue(null)]
        public House House { get; set; }
    }
}
