using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockManagement.Web.Models.StockUnit
{
    public class ListViewModel
    {
        public List<StockManagement.Data.Models.StockUnit.StockUnitDetail> StockUnits { get; set; }
        public StockManagement.Entity.StockUnit StockUnitData { get; set; }

        public List<SelectListItem> StockTypeSelectList { get; set; }
        public List<SelectListItem> QuantityUnitSelectList { get; set; }
        public List<SelectListItem> CurrencySelectList { get; set; }
    }
}
