using StockManagement.Data.Models.StockUnit;
using StockManagement.Business.Abstract;
using StockManagement.Data.Abstract;
using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Data.Models.Stock;

namespace StockManagement.Business.Concrete
{
    public class StockUnitManager : IStockUnitService
    {
        private IStockUnitDal _stockUnitDal;

        public StockUnitManager(IStockUnitDal stockUnitDal)
        {
            _stockUnitDal = stockUnitDal;
        }

        public void Add(StockUnit stockUnit)
        {
            _stockUnitDal.Insert(stockUnit);
        }

        public void Delete(StockUnit stockUnit)
        {
            _stockUnitDal.Delete(stockUnit);
        }
        public void Update(StockUnit stockUnit)
        {
            _stockUnitDal.Update(stockUnit);
        }

        public StockUnit GetById(int id)
        {
            return _stockUnitDal.GetById(id);
        }

        public List<StockUnit> GetList()
        {
            return _stockUnitDal.GetListAll().OrderByDescending(x => x.Id).ToList();
        }

        public List<StockUnitDetail> GetStockUnitDetailList()
        {
            return _stockUnitDal.GetJoinAll().OrderByDescending(x => x.Id).ToList();
        }

        
    }
}
