using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BangazonOrientation.API.Tests
{
    [TestClass]
    public class GetCustomerTests
    {
        CustomerController _controller;
        Mock<ICustomerRepository> _mockedCustomerRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockedCustomerRepository = new Mock<ICustomerRepository>();
            _controller = new CustomerController(_mockedCustomerRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }
        [TestMethod]
        public void GetASingleCustomer()
        {
            //arrange
            int customerId = 1;

            //act
            var result = _controller.RetrieveCustomer(customerId);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void GetAllCustomers()
        {
            //arrange
            //act
            var result = _controller.RetrieveAllCustomers();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

    }
}
