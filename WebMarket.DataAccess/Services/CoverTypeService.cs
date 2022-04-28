using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class CoverTypeService : ICoverTypeService
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(CoverType entity)
        {
            _db.CoverTypes.Add(entity);
        }

        public IEnumerable<CoverType> GetAll()
        {
            IEnumerable<CoverType> query = _db.CoverTypes;
            return query;
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter)
        {
            IQueryable<CoverType> query = _db.CoverTypes;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(CoverType entity)
        {
            _db.CoverTypes.Remove(entity);
        }

        public void RemoveRange(IEnumerable<CoverType> entities)
        {
            _db.CoverTypes.RemoveRange(entities);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CoverType coverType)
        {
            _db.CoverTypes.Update(coverType);
        }
    }
}
