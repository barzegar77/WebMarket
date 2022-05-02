using System.Linq.Expressions;
using WebMarket.DataAccess.Services.Interface;
using WebMarket.Models;

namespace WebMarket.DataAccess.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void Add(Product entity)
        {
            _db.Products.Add(entity);
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

        public void Update(Product product)
        {
            var ObjProduct = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if(ObjProduct != null)
            {
                product.Title = ObjProduct.Title;
                product.Description = ObjProduct.Description;
                product.ShortDescription = ObjProduct.ShortDescription;
                product.ISBN = ObjProduct.ISBN;
                product.Author = ObjProduct.Author;
                product.ListPrice = ObjProduct.ListPrice;
                product.Price = ObjProduct.Price;
                product.Price50 = ObjProduct.Price50;
                product.Price100 = ObjProduct.Price100;
                product.ImgeUrl = ObjProduct.ImgeUrl;
                product.ImageTitle = ObjProduct.ImageTitle;
                product.ImageAlt = ObjProduct.ImageAlt;
                product.CategoryId = ObjProduct.CategoryId;
                product.CoverTypeId = ObjProduct.CoverTypeId;
            }
        }
    }
}
