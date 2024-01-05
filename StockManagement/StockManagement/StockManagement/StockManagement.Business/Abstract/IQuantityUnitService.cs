using StockManagement.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Business.Abstract
{
    public interface IQuantityUnitService
    {
        void Add(QuantityUnit quantityUnit);
        void Delete(QuantityUnit quantityUnit);
        void Update(QuantityUnit quantityUnit);
        List<QuantityUnit> GetList();
        QuantityUnit GetById(int id);
    }
}
