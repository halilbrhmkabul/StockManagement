using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StockManagement.Entity;

namespace StockManagement.Business.Abstract
{
    public interface ICurrencyService
    {
        
        void Add(Currency currencyService);
        void Delete(Currency currencyService);
        void Update(Currency currencyService);
        List<Currency> GetList();
        Currency GetById(int id);
        
    }
}
