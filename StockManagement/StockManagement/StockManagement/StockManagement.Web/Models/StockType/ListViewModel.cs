
namespace StockManagement.Web.Models.StockType
{
    public class ListViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool Status { get; set; }

        public IEnumerable<StockManagement.Entity.StockType> StockType { get; set; }
    }
}
