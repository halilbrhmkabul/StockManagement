using System;
using StockManagement.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IStockTypeService
    {
        void Add(StockType stockType);
        void Delete(StockType stockType);
        void Update(StockType stockType);
        List<StockType> GetList();
        StockType GetById(int id);
    }
}
