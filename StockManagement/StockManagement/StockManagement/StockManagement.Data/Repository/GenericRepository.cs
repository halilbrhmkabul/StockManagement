using StockManagement.Data.Abstract;
using StockManagement.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagement.Data.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Delete(T entity)
        {
            using var c = new StockManagementDbContext();
            c.Remove(entity);
            c.SaveChanges();
        }

        public T GetById(int id)
        {
            using var c = new StockManagementDbContext();
            return c.Set<T>().Find(id);
        }

        public List<T> GetListAll()
        {
            using var c=new StockManagementDbContext();
            return c.Set<T>().ToList();
        }

        public void Insert(T entity)
        {
            using var c=new StockManagementDbContext();
            c.Add(entity);
            c.SaveChanges();
        }

        public void Update(T entity)
        {
            using var c=new StockManagementDbContext();
            c.Update(entity);
            c.SaveChanges();
        }
    }
}
