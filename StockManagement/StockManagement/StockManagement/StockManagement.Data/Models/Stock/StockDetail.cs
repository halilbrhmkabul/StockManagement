using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Models.Stock
{
    public class StockDetail: Entity.Stock
    {
        public int StockClassId { get; set; }
        public string StockClassName { get; set; }
        public int StockUnitCode { get; set; }
        public string StockUnitDescription { get; set; }
        public string StockTypeName { get; set; }
        public string QuantityUnitName { get; set; }
    }
}
