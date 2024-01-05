using StockManagement.Business.Abstract;
using StockManagement.Data.Abstract;
using StockManagement.Entity;
using StockManagement.Data.Models.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Concrete
{
    public class StockManager : IStockService
    {
        private IStockDal _stockDal;

        public StockManager(IStockDal stockDal)
        {
            _stockDal = stockDal;
        }

        public void Add(Stock stock)
        {
            _stockDal.Insert(stock);
        }

        public void Delete(Stock stock)
        {
            _stockDal.Delete(stock);
        }

        public Stock GetById(int id)
        {
            throw new NotImplementedException();
        }
        public void Update(Stock stock)
        {
            _stockDal.Update(stock);
        }
        public List<Stock> GetList()
        {
           return _stockDal.GetListAll();
        }

        public List<StockDetail> GetStockDetailList()
        {
            return _stockDal.GetJoinAll();
        }

       
    }
}
