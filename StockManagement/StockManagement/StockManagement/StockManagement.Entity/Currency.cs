using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    public class Currency
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Symbol { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
