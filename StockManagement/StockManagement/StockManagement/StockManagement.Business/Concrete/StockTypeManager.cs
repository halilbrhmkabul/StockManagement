using StockManagement.Business.Abstract;
using StockManagement.Data.Abstract;
using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Concrete
{
    public class StockTypeManager : IStockTypeService
    {
        private IStockTypeDal _StockTypeDal;

        public StockTypeManager(IStockTypeDal stockTypeDal)
        {
            _StockTypeDal = stockTypeDal;
        }

        public StockType GetById(int id)
        {
            return _StockTypeDal.GetById(id);
        }

        public List<StockType> GetList()
        {
            return _StockTypeDal.GetListAll().OrderByDescending(x => x.Id).ToList();
        }

        public void Add(StockType stockType)
        {
            _StockTypeDal.Insert(stockType);
        }

        public void Delete(StockType stockType)
        {
            _StockTypeDal.Delete(stockType);
        }

        public void Update(StockType stockType)
        {
            _StockTypeDal.Update(stockType);
        }
    }
}
