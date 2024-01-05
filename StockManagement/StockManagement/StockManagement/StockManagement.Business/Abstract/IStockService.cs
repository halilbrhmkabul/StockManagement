using StockManagement.Entity;
using StockManagement.Data.Models.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IStockService
    {
        void Add(Stock stock);
        void Delete(Stock stock);
        void Update(Stock stock);
        List<Stock> GetList();
        Stock GetById(int id);

        List<StockDetail> GetStockDetailList();
    }
}
