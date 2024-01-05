using StockManagement.Data.Abstract;
using StockManagement.Data.Repository;
using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Concrete.EfCore
{
    public class EfCoreStockTypeDal: GenericRepository<StockType>, IStockTypeDal
    {
    }
}
