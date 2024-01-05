using System;
using StockManagement.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagement.Data.Models.Stock;
using StockManagement.Data.Models.StockUnit;

namespace StockManagement.Business.Abstract
{
    public interface IStockUnitService
    {
        void Add(StockUnit stockUnit);
        void Delete(StockUnit stockUnit);
        void Update(StockUnit stockUnit);
        List<StockUnit> GetList();
        StockUnit GetById(int id);

        List<StockUnitDetail> GetStockUnitDetailList();
    }
}
