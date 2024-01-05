using Microsoft.AspNetCore.Mvc.Rendering;
using StockManagement.Data.Models.Stock;
namespace StockManagement.Web.Models.Stock
{
    public class ListViewModel
    {
        public List<StockDetail> Stocks { get; set; }
        public StockManagement.Entity.Stock Stock { get; set; }
        public List<SelectListItem> StockClassSelectList { get; set; }
        public List<SelectListItem> StockTypeSelectList { get; set; }
        public List<SelectListItem> StockUnitSelectList { get; set; }
    }
}
