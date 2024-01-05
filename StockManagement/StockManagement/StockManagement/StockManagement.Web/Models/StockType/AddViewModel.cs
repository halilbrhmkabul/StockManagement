using System.ComponentModel.DataAnnotations;

namespace StockManagement.Web.Models.StockType
{
    public class AddViewModel
    {
        [Required(ErrorMessage = " Stok Türü boş geçilemez!")]
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
