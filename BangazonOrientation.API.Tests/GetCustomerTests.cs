using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
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
        public void EnsureICanGetASingleCustomerSuccessfully()
        {
            //arrange
            int customerId = 1;
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(1))
                .Returns(() =>
                    new Customer {CustomerId = 1, CustomerName = "Jimmy"}
                  );
            //act
            var result = _controller.RetrieveCustomer(customerId);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void EnsureABadRequestIsThrownWhenACustomerDoesNotExist()
        {
            //arrange
            int customerId = 1;
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(1))
                .Returns(() =>
                    null
                );
            //act
            var result = _controller.RetrieveCustomer(customerId);

            //assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void EnsureICanGetAllCustomersSuccessfully()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetAllCustomers())
                .Returns(() =>
                    new List<Customer>
                    {
                        new Customer {CustomerId = 1, CustomerName = "Jimmy"},
                        new Customer {CustomerId = 2, CustomerName = "Steve"},
                        new Customer {CustomerId = 3, CustomerName = "Sally"}
                    });

            //act
            var result = _controller.RetrieveAllCustomers();

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void EnsureABadRequestIsThrownWhenThereAreNoCustomers()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetAllCustomers())
                .Returns(() =>
                    null
                    );

            //act
            var result = _controller.RetrieveAllCustomers();

            //assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

    }
}
