using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Charge
    {
        public long Id { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "decimal")]
        public decimal Value { get; set; }

        [NotMapped]
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

        [DefaultValue(MonthEnum.JANUARY)]
        public MonthEnum Month { get; set; }

        [DefaultValue(1970)]
        [Column(TypeName = "integer")]
        public int Year { get; set; }

        [DefaultValue(false)]
        [Column(TypeName = "boolean")]
        public bool IsPaymentCompleted { get; set; }

        [DefaultValue(null)]
        public IEnumerable<Payment> Payments { get; set; }

        [DefaultValue(null)]
        public Saldo Saldo { get; set; }

        public long HouseId  { get; set; }

        [DefaultValue(null)]
        [ForeignKey("HouseId")]
        public House House { get; set; }
    }
}
