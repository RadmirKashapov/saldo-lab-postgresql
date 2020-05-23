using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Charge
    {
        [Column(TypeName = "varchar(500)")]
        public string Id { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Value { get; set; }

        [Required]
        public virtual int MonthEnumId
        {
            get
            {
                return (int)this.Month;
            }
            set
            {
                Month = (MonthEnum)value;
            }
        }
        [EnumDataType(typeof(MonthEnum))]
        public MonthEnum Month { get; set; }

        [Column(TypeName = "integer")]
        public int Year { get; set; }

        [Column(TypeName = "boolean")]
        public bool IsPayment { get; set; }

        public IEnumerable<Payment> Payments { get; set; }
        public Saldo Saldo { get; set; }
        
        public string HouseId { get; set; }

        [ForeignKey("HouseId")]
        public House House { get; set; }


    }
}
