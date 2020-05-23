﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Saldo
    {
        [Column(TypeName = "varchar(500)")]
        public string Id { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Value { get; set; }

        [Column(TypeName = "integer")]
        public int Year { get; set; }

        [Column(TypeName = "timestamp")]
        public DateTime Date { get; set; }

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
        public string ChargeId { get; set; }

        [ForeignKey("ChargeId")]
        public Charge Charge { get; set; }

    }
}
