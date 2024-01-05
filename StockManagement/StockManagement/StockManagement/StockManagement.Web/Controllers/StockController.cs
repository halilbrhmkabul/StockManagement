using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockManagement.Business.Abstract;
using StockManagement.Web.Models.Stock;

namespace StockManagement.Web.Controllers
{
    public class StockController : Controller
    {
        private  IStockService _stockService;
        private  IStockClassService _stockClassService;
        private  IStockTypeService _stockTypeService;
        private  IStockUnitService _stockUnitService;

        public StockController(IStockService stockService, IStockClassService stockClassService, IStockTypeService stockTypeService,  IStockUnitService stockUnitService)
        {
            _stockService = stockService;
            _stockClassService = stockClassService;
            _stockUnitService = stockUnitService;
            _stockTypeService = stockTypeService;
        }

        public IActionResult Index()
        {

            ListViewModel model = new ListViewModel();

            model.Stocks = _stockService.GetStockDetailList();
            model.StockClassSelectList = GetStockClassSelectList();
            model.StockTypeSelectList = GetStockTypeSelectList();
            model.StockUnitSelectList = GetStockUnitSelectList();

            return View(model);
        }

        [HttpGet]
        public IActionResult DataTable()
        {
            return View();
        }

        public IActionResult DataTableJson()
        {
            try // sıralama
            {
                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;



                string strSql = @"select * from dbo.Stocks s where 1=1 ";

                if (!string.IsNullOrEmpty(searchValue))
                {
                    strSql += @" and (s.UnitCode like '%" + searchValue + "%' or s.Name like '" + searchValue + "') ";
                }

                if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
                {
                    strSql = strSql + " order by s." + sortColumn + " " + sortColumnDirection;
                }
                strSql += " offset " + skip.ToString() + " rows fetch next " + pageSize.ToString() + " rows only ";


                var stockdata = _stockService.GetList();

                
                if (!string.IsNullOrEmpty(searchValue))
                {
                    stockdata = stockdata.Where(x => x.Name.ToLower().Contains(searchValue.ToLower())
                    || x.Id.ToString().Contains(searchValue))
                        .ToList();
                }
                recordsTotal = stockdata.Count();
                var data = stockdata.Skip(skip).Take(pageSize).ToList();
                var jsondata = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
                return Ok(jsondata);
            }
            catch (Exception e)
            {
                return View();
                throw;
            }
        }

        [HttpPost]
        public IActionResult Add(ListViewModel model)
        {
            StockManagement.Entity.Stock record = new Entity.Stock();

            record.StockClassId = model.Stock.StockClassId;
            record.StockTypeId = model.Stock.StockTypeId;
            record.Name = null;
            record.Quantity = model.Stock.Quantity;
            record.Shelf = model.Stock.Shelf;
            record.Cupboard = model.Stock.Cupboard;
            record.CriticQuantity = model.Stock.CriticQuantity;
            record.Status = model.Stock.Status;
            record.StockUnitId = model.Stock.StockUnitId;

            _stockService.Add(record);

            if (record.Id == null)
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Kayıt eklenmedi!";
            }
            else
            {
                TempData["Message"] = "Başarılı";
                TempData["Message_Detail"] = "Kayıt başarıyla eklendi!";
            }

            return Redirect("~/Stock");

        }

        [HttpGet]
        public JsonResult GetDetailsById(int id)
        {
            Entity.Stock model = _stockService.GetById(id);

            if (model != null)
            {
                return Json(model);
            }
            else
            {
                TempData["Message"] = "Hata";
                TempData["Message_Detail"] = "Kayıt bulunamadı!";
                return Json(TempData);
            }
        }

        [HttpPost]
        public IActionResult Update(ListViewModel model)
        {
            Entity.Stock record = _stockService.GetById(model.Stock.Id);
            if (record != null)
            {
                record.UnitCode = 0;
                record.Name = null;
                record.StockClassId = model.Stock.StockClassId;
                record.StockTypeId = model.Stock.StockTypeId;
                record.Quantity = model.Stock.Quantity;
                record.Shelf = model.Stock.Shelf;
                record.Cupboard = model.Stock.Cupboard;
                record.CriticQuantity = model.Stock.CriticQuantity;
                record.Status = model.Stock.Status;
                record.StockUnitId = model.Stock.StockUnitId;

                _stockService.Update(record);

                if (record.Id == null)
                {
                    TempData["Message"] = "Hata";
                    TempData["Message_Detail"] = "Stok güncellenemedi!";
                }
                else
                {
                    TempData["Message"] = "Başarılı";
                    TempData["Message_Detail"] = "Stok başarıyla güncellendi!";
                }
            }
            return Redirect("~/Stock");
        }

        private List<SelectListItem> GetStockTypeSelectList()
        {
            return _stockTypeService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }

        private List<SelectListItem> GetStockUnitSelectList()
        {
            return _stockUnitService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Description) }).ToList();
        }

        private List<SelectListItem> GetStockClassSelectList()
        {
            return _stockClassService.GetList().Where(x => x.Status == true).Select(r => new SelectListItem() { Value = r.Id.ToString(), Text = string.Format("{0}", r.Name) }).ToList();
        }
    }
}
