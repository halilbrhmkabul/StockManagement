using Microsoft.AspNetCore.Mvc;
using StockManagement.Web.Models.Stock;
using StockManagement.Business.Abstract;
using StockManagement.Web.Models.StockUnit;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace StockManagement.Web.Controllers
{
    public class StockUnitController : Controller
    {
        private IStockUnitService _stockUnitService;
        private IStockTypeService _stockTypeService;
        private IQuantityUnitService _quantityUnitService;
        private ICurrencyService _currencyService;

        public StockUnitController(IStockUnitService stockUnitService, IStockTypeService stockTypeService, IQuantityUnitService quantityUnitService, ICurrencyService currencyService)
        {
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
            _quantityUnitService = quantityUnitService;
            _currencyService = currencyService;
        }

        public IActionResult Index()
        {
            StockManagement.Web.Models.StockUnit.ListViewModel model = new StockManagement.Web.Models.StockUnit.ListViewModel();

            model.StockUnits = _stockUnitService.GetStockUnitDetailList();

            model.StockTypeSelectList = GetStockTypeSelectList();
            model.QuantityUnitSelectList = GetQuantityUnitSelectList();
            model.CurrencySelectList = GetCurrencySelectList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Add(StockManagement.Web.Models.StockUnit.ListViewModel model)
        {
            StockManagement.Entity.StockUnit record = new StockManagement.Entity.StockUnit();
            
            var control = _stockUnitService.GetList().Where(x => x.UnitCode == model.StockUnitData.UnitCode).FirstOrDefault();
            if (control == null)
            {
                record.UnitCode = model.StockUnitData.UnitCode;
                record.StockTypeId = model.StockUnitData.StockTypeId;
                record.QuantityUnitId = model.StockUnitData.QuantityUnitId;
                record.Description = model.StockUnitData.Description;
                record.BuyingPrice = model.StockUnitData.BuyingPrice;
                record.BuyingCurrencyId = model.StockUnitData.BuyingCurrencyId;
                record.SalePrice = model.StockUnitData.SalePrice;
                record.SaleCurrencyId = model.StockUnitData.SaleCurrencyId;
                record.PaperWeight = model.StockUnitData.PaperWeight;
                record.Status = model.StockUnitData.Status;
                record.CurrencyId = 1;

                _stockUnitService.Add(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Hata";
                    TempData["Message_Detail"] = "Kayıt eklenemedi!";
                }
                else
                {
                    TempData["Message"] = "Başarılı";
                    TempData["Message_Detail"] = "Kayıt başarıyla eklendi!";
                }
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Aynı kayıt bulunmaktadır!";
            }
            return Redirect("~/StockUnit");
        }

        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            StockManagement.Entity.StockUnit stockUnit = _stockUnitService.GetById(id);
            StockManagement.Entity.StockUnit model = new StockManagement.Entity.StockUnit();

            if (stockUnit != null)
            {
                model.Id = stockUnit.Id;
                model.UnitCode = stockUnit.UnitCode;
                model.StockTypeId = stockUnit.StockTypeId;
                model.QuantityUnitId = stockUnit.QuantityUnitId;
                model.Description = stockUnit.Description;
                model.BuyingPrice = stockUnit.BuyingPrice;
                model.BuyingCurrencyId = stockUnit.BuyingCurrencyId;
                model.SalePrice = stockUnit.SalePrice;
                model.SaleCurrencyId = stockUnit.SaleCurrencyId;
                model.PaperWeight = stockUnit.PaperWeight;
                model.Status = stockUnit.Status;
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Stok Birimi bulunamadı!";
            }
            return Json(model);
        }
        [HttpPost]
        public IActionResult Update(StockManagement.Web.Models.StockUnit.ListViewModel model)
        {
            StockManagement.Entity.StockUnit record = _stockUnitService.GetById(model.StockUnitData.Id);

            if (record != null)
            {
                record.UnitCode = model.StockUnitData.UnitCode;
                record.StockTypeId = model.StockUnitData.StockTypeId;
                record.QuantityUnitId = model.StockUnitData.QuantityUnitId;
                record.Description = model.StockUnitData.Description;
                record.BuyingPrice = model.StockUnitData.BuyingPrice;
                record.SalePrice = model.StockUnitData.SalePrice;
                record.BuyingCurrencyId = model.StockUnitData.BuyingCurrencyId;
                record.SaleCurrencyId = model.StockUnitData.SaleCurrencyId;
                record.PaperWeight = model.StockUnitData.PaperWeight;
                record.Status = model.StockUnitData.Status;
                record.CurrencyId = 1;

                _stockUnitService.Update(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Error";
                    TempData["Message_Detail"] = "Stok Birimi güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Success";
                    TempData["Message_Detail"] = "Stok Birimi başarıyla güncellendi!";
                }
            }
            return Redirect("~/StockUnit");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var record = _stockUnitService.GetById(id);

            if (record != null)
            {
                _stockUnitService.Delete(record);

                TempData["Message"] = "Başarılı";
                TempData["Message_Detail"] = "Stok Birimi başarıyla silindi!";
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Stok Birimi bulunamadı!";
            }

            return Redirect("~/StockUnit");
        }


        private List<SelectListItem> GetCurrencySelectList()
        {
            return _currencyService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetQuantityUnitSelectList()
        {
            return _quantityUnitService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetStockTypeSelectList()
        {
            return _stockTypeService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

    }
}
