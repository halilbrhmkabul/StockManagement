using Microsoft.AspNetCore.Mvc;
using StockManagement.Business.Abstract;
using StockManagement.Entity;
using StockManagement.Web.Models.StockType;

namespace StockManagement.Web.Controllers
{
    public class StockTypeController : Controller
    {
        private IStockTypeService _stockTypeService;

        public StockTypeController(IStockTypeService stockTypeService)
        {
            _stockTypeService = stockTypeService;
        }


        public IActionResult Index()
        {
            ListViewModel model = new ListViewModel();
            model.StockType = _stockTypeService.GetList();
            return View(model);
        }


        [HttpPost]
        public IActionResult Add(ListViewModel model)
        {
            StockType record = new StockType();

            if (model.Name == null)
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Stok Türü adı boş olmamalıdır!";
            }
            var control =  _stockTypeService.GetList().Where(x => x.Name.ToLower().Contains(model.Name.ToLower())).FirstOrDefault();
            if (control == null)
            {
               // record.Id = model.Id;
                record.Name = model.Name;
                record.Status = model.Status;
                _stockTypeService.Add(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Hata";
                    TempData["Message_Detail"] = "Kayıt işlemi başarısız!";
                }
                else
                {
                    TempData["Message"] = "Başarılı";
                    TempData["Message_Detail"] = "Kayıt işlemi başarılı!";
                }
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Bu kayıttan var!";
            }

        
            return Redirect("~/StockType");
        }

        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            var stockType = _stockTypeService.GetById(id);
            ListViewModel model = new ListViewModel();

            if (stockType != null)
            {
                model.Id = stockType.Id;
                model.Name = stockType.Name;
                model.Status = stockType.Status;
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Kayıt bulunamadı!";
            }
            return Json(model);
        }

        [HttpPost]
        public IActionResult Update(ListViewModel model)
        {
            StockManagement.Entity.StockType record = _stockTypeService.GetById(model.Id);
            if (record != null)
            {
                record.Name = model.Name;
                record.Status = model.Status;

                _stockTypeService.Update(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Hata";
                    TempData["Message_Detail"] = "Kayıt güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Başarılı";
                    TempData["Message_Detail"] = "Kayıt güncellendi!";
                }
            }
            return Redirect("~/StockType");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var stockType = _stockTypeService.GetById(id);

                if (stockType == null)
                {
                    TempData["Message"] = "Hata";
                    TempData["Message_Detail"] = "Kayıt bulunamadı!";
                }
                else
                {
                    _stockTypeService.Delete(stockType);

                    TempData["Message"] = "Başarılı";
                    TempData["Message_Detail"] = "Kayıt silindi!";
                }
            }
            catch (Exception ex)
            {
               
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Silme işlemi sırasında bir hata oluştu!";
            }

            return Redirect("~/StockType");
        }
    }
}
