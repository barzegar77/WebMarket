using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services.Interface
{
    public interface ICompanyService
    {
        public void Add(Company entity);
        public IEnumerable<Company> GetAll();
        public Company GetFirstOrDefault(Expression<Func<Company, bool>> filter);
        public void Remove(Company entity);
        public void RemoveRange(IEnumerable<Company> entities);
        public void Update(Company company);
    }
}
