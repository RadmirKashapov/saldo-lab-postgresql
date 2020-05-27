using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Saldo
    {
        public long Id { get; set; }

        [DefaultValue(0)]
        [Column(TypeName = "decimal")]
        public decimal Value { get; set; }

        [DefaultValue(1970)]
        [Column(TypeName = "integer")]
        public int Year { get; set; }

        [DefaultValue(typeof(DateTime))]
        [Column(TypeName = "timestamp")]
        public DateTime Date { get; set; } = DateTime.UtcNow;

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

        [DefaultValue(MonthEnum.JANUARY)]
        [EnumDataType(typeof(MonthEnum))]
        public MonthEnum Month { get; set; }

        public long ChargeId { get; set; }

        [DefaultValue(null)]
        [ForeignKey("ChargeId")]
        public Charge Charge { get; set; }

    }
}
