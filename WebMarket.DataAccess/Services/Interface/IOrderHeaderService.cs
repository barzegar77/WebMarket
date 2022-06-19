using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface IOrderHeaderService
    {
        public void Add(OrderHeader entity);
        public IEnumerable<OrderHeader> GetAll();
        public OrderHeader GetFirstOrDefault(Expression<Func<OrderHeader, bool>> filter);
        public void Remove(OrderHeader entity);
        public void RemoveRange(IEnumerable<OrderHeader> entities);
        public void Update(OrderHeader orderHeader);

        void UpdateStatus(int id, string orderStatus, string? paymentStatus = null);
    }
}
