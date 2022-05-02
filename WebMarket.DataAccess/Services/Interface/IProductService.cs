using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IProductService
    {
        public void Add(Product entity);
        public IEnumerable<Product> GetAll();
        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter);
        public void Remove(Product entity);
        public void RemoveRange(IEnumerable<Product> entities);
        public void Update(Product product);
    }
}
