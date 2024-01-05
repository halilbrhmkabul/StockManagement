using System;
using StockManagement.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IStockClassService
    {
        void Add(StockClasses stockClasses);
        void Delete(StockClasses stockClasses);
        void Update(StockClasses stockClasses);
        List<StockClasses> GetList();
        StockClasses GetById(int id);
    }
}
