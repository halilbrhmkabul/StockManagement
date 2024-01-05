namespace StockManagement.Web.Models.StockUnit
{
    public class StockUnitDetail : StockManagement.Entity.StockUnit
    {
        public string StockTypeName { get; set; }
        public string QuantityUnitName { get; set; }
        public string BuyingCurrencySymbol { get; set; }
        public string SaleCurrencySymbol { get; set; }
    }
}
