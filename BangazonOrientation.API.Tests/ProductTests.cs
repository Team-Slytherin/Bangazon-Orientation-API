using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonOrientation.API.Controllers;
using Moq;
using BangazonOrientation.API.Interfaces;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Models;
using System.Net;

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
        public void EnsureCanGetOneProductById()
        {
        }

        [TestMethod]
        public void EnsureCanGetAllProducts()
        {
        }

        [TestMethod]
        public void EnsureCanEditSingleProductName()
        {
        }

        [TestMethod]
        public void EnsureCanEditSingleProductPrice()
        {
        }

        [TestMethod]
        public void EnsureCanEditSingleProductObject()
        {
        }
    }
}
