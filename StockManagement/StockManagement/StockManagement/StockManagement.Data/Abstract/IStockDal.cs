using StockManagement.Data.Models.Stock;
using StockManagement.Data.Models.StockUnit;
using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Abstract
{
    public interface IStockDal:IGenericDal<Stock>
    {
        public List<StockDetail> GetJoinAll();
    }
}
