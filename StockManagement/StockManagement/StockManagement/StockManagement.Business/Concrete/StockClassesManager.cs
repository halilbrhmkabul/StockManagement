using StockManagement.Entity;
using StockManagement.Business.Abstract;
using StockManagement.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Concrete
{
    public class StockClassManager : IStockClassService
    {
        private IStockClassDal _stockClassDal;

        public StockClassManager(IStockClassDal stockClassDal)
        {
            _stockClassDal = stockClassDal;
        }

        public void Add(StockClasses stockClasses)
        {
            _stockClassDal.Insert(stockClasses);
        }

        public void Delete(StockClasses stockClasses)
        {
            _stockClassDal.Delete(stockClasses);
        }

        public StockClasses GetById(int id)
        {
            return _stockClassDal.GetById(id);
        }

        public List<StockClasses> GetList()
        {
            return _stockClassDal.GetListAll();
        }

        public void Update(StockClasses stockClasses)
        {
            _stockClassDal.Update(stockClasses);
        }
    }
}
