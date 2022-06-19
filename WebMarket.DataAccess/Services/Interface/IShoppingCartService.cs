using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IShoppingCartService
    {
        public void Add(ShoppingCart entity);
        public IEnumerable<ShoppingCart> GetAll();
        public ShoppingCart GetFirstOrDefault(Expression<Func<ShoppingCart, bool>> filter);
        public void Remove(ShoppingCart entity);
        public void RemoveRange(IEnumerable<ShoppingCart> entities);
        public void Update(ShoppingCart entity);

        int IncrementCount(ShoppingCart shoppingCart, int count);

        int DecrementCount(ShoppingCart shoppingCart, int count);
    }
}
