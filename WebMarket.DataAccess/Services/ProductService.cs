using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;
using WebMarket.Models.ViewModels;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(ProductVM entity)
        {
            _db.Products.Add(entity.Product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products.Include(c => c.Category).Include(c => c.CoverType);
            return query;
        }

        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }

        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
            _db.SaveChanges();
        }

        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
            _db.SaveChanges();
        }

        public void Update(Product obj)
        {
            var ObjProduct = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if(ObjProduct != null)
            {
                ObjProduct.Title = obj.Title;
                ObjProduct.Description = obj.Description;
                ObjProduct.ShortDescription = obj.ShortDescription;
                ObjProduct.ISBN = obj.ISBN;
                ObjProduct.Author = obj.Author;
                ObjProduct.ListPrice = obj.ListPrice;
                ObjProduct.Price = obj.Price;
                ObjProduct.Price50 = obj.Price50;
                ObjProduct.Price100 = obj.Price100;
                if (obj.ImgeUrl != null)
                {
                    ObjProduct.ImgeUrl = obj.ImgeUrl;
                }
                ObjProduct.ImageTitle = obj.ImageTitle;
                ObjProduct.ImageAlt = obj.ImageAlt;
                ObjProduct.CategoryId = obj.CategoryId;
                ObjProduct.CoverTypeId = obj.CoverTypeId;
            }

            _db.SaveChanges();

        }
    }
}
