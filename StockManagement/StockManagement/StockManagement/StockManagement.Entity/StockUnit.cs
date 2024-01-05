using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Entity
{
    public class StockUnit
    {
        [Key]
        public int Id { get; set; }
        public int UnitCode { get; set; } = 0;
        public int StockTypeId { get; set; }
        public int QuantityUnitId { get; set; }
        public string? Description { get; set; }
        public float BuyingPrice { get; set; }
        public float SalePrice { get; set; }
        public int BuyingCurrencyId { get; set; }
        public int SaleCurrencyId { get; set; }
        public int PaperWeight { get; set; }
        public bool Status { get; set; }
        public int CurrencyId { get; set; }
    }
}
