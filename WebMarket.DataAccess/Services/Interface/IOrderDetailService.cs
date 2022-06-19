using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IOrderDetailService
    {
        public void Add(OrderDetails entity);
        public IEnumerable<OrderDetails> GetAll();
        public OrderDetails GetFirstOrDefault(Expression<Func<OrderDetails, bool>> filter);
        public void Remove(OrderDetails entity);
        public void RemoveRange(IEnumerable<OrderDetails> entities);
        public void Update(OrderDetails orderDetails);
    }
}
