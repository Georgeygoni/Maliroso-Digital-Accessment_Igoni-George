using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maliroso_Task3_Databases
{
    public class SqldbRepository
    {
        private readonly ApplicationDbContext _db;

        public SqldbRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public void UpdateProduct(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _db.Products.Find(productId);
            if (product != null)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
            }
        }
    }

}
