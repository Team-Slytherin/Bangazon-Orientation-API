using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonOrientation.API.Controllers;
using Moq;
using BangazonOrientation.API.Interfaces;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Models;
using System.Net;
using System.Collections.Generic;

namespace BangazonOrientation.API.Tests
{
    [TestClass]
    public class ProductTests
    {

        ProductController _productController;
        Mock<IProductRepository> _mockedProductRepository;
        Product product1;
        Product product2;
        Product product3;
        Product product4;
        Product badProduct;

        [TestInitialize]
        public void Initialize()
        {
            _mockedProductRepository = new Mock<IProductRepository>();
            _productController = new ProductController(_mockedProductRepository.Object);
            _productController.Request = new HttpRequestMessage();
            _productController.Request.SetConfiguration(new HttpConfiguration());
            product1 = new Product
            {
                ProductId = 0001,
                ProductName = "Tennis Balls",
                ProductPrice = 9.99m
            };
            product2 = new Product
            {
                ProductId = 0002,
                ProductName = "Country Ham",
                ProductPrice = 16.99m
            };
            product3 = new Product
            {
                ProductId = 0003,
                ProductName = "Malibu Barbie",
                ProductPrice = 14.99m
            };
            product4 = new Product
            {
                ProductId = 0004,
                ProductName = "Shitzu",
                ProductPrice = 750.00m
            };
            badProduct = new Product();
        }
        [TestMethod]
        public void EnsureAddProductIsSuccessful()
        {
            var result = _productController.AddNewProduct(product1);
            Assert.IsTrue(result.IsSuccessStatusCode);
        }

        [TestMethod]
        public void EnsureAddProductReturns400WhenProductEmpty()
        {
            _productController.ModelState.AddModelError("problems", new Exception());
            var result = _productController.AddNewProduct(badProduct);
            Assert.IsTrue(result.StatusCode == HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void EnsureCanGetOneProductById(Product product1)
        {
            _mockedProductRepository.Setup(x => x.GetOneProduct(product1.ProductId))
                    .Returns(() => new Product { ProductId = 0001, ProductName = "Tennis Balls", ProductPrice = 9.99m }
                    );
            var result = _productController.GetOneProduct(product1.ProductId);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void EnsureCanGetAllProducts()
        {
            //arrange
            _mockedProductRepository.Setup(x => x.GetAllProducts())
                .Returns(() =>
                    new List<Product>
                    {
                        product1, product2, product3, product4
                    });

            //act
            var result = _productController.GetAllProducts();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void EnsureCanEditSingleProduct()
        {
            var updatedProduct4 =
                new Product
                {
                    ProductId = 0004,
                    ProductName = "Beagle",
                    ProductPrice = 250.00m
                };
            var result = _productController.EditOneProduct(updatedProduct4);
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
