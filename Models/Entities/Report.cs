using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SladoLab.Models.Entities
{
    public class Report
    {
        public string Id { get; set; }
        public string SaldoId { get; set; }
        public string ChargesId { get; set; }
        public string PaymentId { get; set; }
        public string HouseIs { get; set; }
        public DateTime Date { get; set; }
    }
}
