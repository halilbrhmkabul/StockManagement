using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Models.StockUnit
{
    public class StockUnitDetail: StockManagement.Entity.StockUnit
    {
        public string StockTypeName { get; set; }
        public string QuantityUnitName { get; set; }
        public string BuyingCurrencySymbol { get; set; }
        public string SaleCurrencySymbol { get; set; }
    }
}
