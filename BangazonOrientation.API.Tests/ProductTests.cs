using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonOrientation.API.Controllers;
using Moq;
using BangazonOrientation.API.Interfaces;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Models;

namespace BangazonOrientation.API.Tests
{
    [TestClass]
    public class ProductTests
    {

        ProductController _productController;
        Mock<IProductRepository> _mockedProductRepository;
        Product product1;
        Product product2;


        [TestInitialize]
        public void Initialize()
        {
            _mockedProductRepository = new Mock<IProductRepository>();
            _productController = new ProductController(_mockedProductRepository.Object);
            _productController.Request = new HttpRequestMessage();
            _productController.Request.SetConfiguration(new HttpConfiguration());
            var product1 = new Product
            {
                ProductId = 1,
                ProductName = "Tennis Balls",
                ProductPrice = 9.99m
            };
            var product2 = new Product
            {
                ProductId = 2,
                ProductName = "Country Ham",
                ProductPrice = 16.99m
            };
        }
        [TestMethod]
        public void EnsureAddNewProductNotEmpty()
        {
        }

        [TestMethod]
        public void EnsureAddNewProductPostsToDatabase()
        {
        }

        [TestMethod]
        public void EnsureAddNewProductNotDuplicate()
        {
        }

        [TestMethod]
        public void EnsureAddNewProductNameValid()
        {
        }

        [TestMethod]
        public void EnsureAddNewProductPriceValid()
        {
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
