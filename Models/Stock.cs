using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR(50)")]
        public string Symbol { get; set; } = string.Empty;

        [Column(TypeName = "VARCHAR(255)")]
        public string CompanyName { get; set; } = string.Empty;

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal Purchase { get; set; }

        [Column(TypeName = "DECIMAL(18,2)")]
        public decimal LastDiv { get; set; }

        [Column(TypeName = "VARCHAR(255)")]
        public string Industry { get; set; } = string.Empty;

        public long MarketCap { get; set; }
    }
}