using BangazonOrientation.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BangazonOrientation.API.Models;

namespace BangazonOrientation.API.DAL
{
    public class ProductRepository : IProductRepository
    {
        public void AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetOneProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(Product productToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}