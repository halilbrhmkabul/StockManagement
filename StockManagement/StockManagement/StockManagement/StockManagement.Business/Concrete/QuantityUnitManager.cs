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
    public class QuantityUnitManager : IQuantityUnitService
    {
        private IQuantityUnitDal _quantityUnitDal;

        public QuantityUnitManager(IQuantityUnitDal quantityUnitDal)
        {
            _quantityUnitDal = quantityUnitDal;
        }

        public void Add(QuantityUnit quantityUnit)
        {
            _quantityUnitDal.Insert(quantityUnit);
        }

        public void Delete(QuantityUnit quantityUnit)
        {
            _quantityUnitDal.Delete(quantityUnit);
        }

        public void Update(QuantityUnit quantityUnit)
        {
            _quantityUnitDal.Update(quantityUnit);
        }

        public QuantityUnit GetById(int id)
        {
           return _quantityUnitDal.GetById(id);
        }

        public List<QuantityUnit> GetList()
        {
            return _quantityUnitDal.GetListAll();
        }
       
    }
}
