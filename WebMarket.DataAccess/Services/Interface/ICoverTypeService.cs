using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICoverTypeService
    {
        public void Add(CoverType entity);
        public IEnumerable<CoverType> GetAll();
        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter);
        public void Remove(CoverType entity);
        public void RemoveRange(IEnumerable<CoverType> entities);
        public void Update(CoverType coverType);
    }
}
