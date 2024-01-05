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
    public class CurrencyManager : ICurrencyService
    {
        private ICurrencyDal _currencyDal;

        public CurrencyManager(ICurrencyDal currencyDal)
        {
            _currencyDal = currencyDal;
        }

        public void Add(Currency currency)
        {
            _currencyDal.Insert(currency);
        }

        public void Delete(Currency currency)
        {
            _currencyDal.Delete(currency);
        }
        public void Update(Currency currency)
        {
            _currencyDal.Update(currency);
        }
        public List<Currency> GetList()
        {
            return _currencyDal.GetListAll();
        }

        public Currency GetById(int id)
        {
            return _currencyDal.GetById(id);
        }

        
    }
}
