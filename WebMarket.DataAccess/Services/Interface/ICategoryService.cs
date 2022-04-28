using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICategoryService
    {
        public void Add(Category entity);
        public IEnumerable<Category> GetAll();
        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter);
        public void Remove(Category entity);
        public void RemoveRange(IEnumerable<Category> entities);
        public void Update(Category category);
    }
}
