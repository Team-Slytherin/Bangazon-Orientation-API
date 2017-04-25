using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BangazonOrientation.API.Interfaces
{
    public interface IProductRepository
    {
        void AddProduct(Product newProduct);
        Product GetOneProduct(int productId);
        IEnumerable<Product> GetAllProducts();
        void UpdateProduct(Product productToUpdate);
    }
}
