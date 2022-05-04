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
            IEnumerable<Product> query = _db.Products;
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

        public void Update(ProductVM obj)
        {
            var ObjProduct = _db.Products.FirstOrDefault(x => x.Id == obj.Product.Id);
            if(ObjProduct != null)
            {
                obj.Product.Title = ObjProduct.Title;
                obj.Product.Description = ObjProduct.Description;
                obj.Product.ShortDescription = ObjProduct.ShortDescription;
                obj.Product.ISBN = ObjProduct.ISBN;
                obj.Product.Author = ObjProduct.Author;
                obj.Product.ListPrice = ObjProduct.ListPrice;
                obj.Product.Price = ObjProduct.Price;
                obj.Product.Price50 = ObjProduct.Price50;
                obj.Product.Price100 = ObjProduct.Price100;
                obj.Product.ImgeUrl = ObjProduct.ImgeUrl;
                obj.Product.ImageTitle = ObjProduct.ImageTitle;
                obj.Product.ImageAlt = ObjProduct.ImageAlt;
                obj.Product.CategoryId = ObjProduct.CategoryId;
                obj.Product.CoverTypeId = ObjProduct.CoverTypeId;
            }
        }
    }
}
