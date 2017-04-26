using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BangazonOrientation.API.Tests
{
    [TestClass]
    public class EditCustomerTests
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
        public void EnsureAnEditedCustomerCantBeSavedWithoutAllRequiredFields()
        {
            ////arrange
            //var CustomerToEdit =
            //        new Customer
            //        {
            //            CustomerName = "Taylor",
            //            CustomerStreetAddress = "123 Update Street",
            //            CustomerCity = "Awesomeville",
            //            CustomerState = "TN",
            //            CustomerZip = "37069",
            //            CustomerPhone = "6158675309"
            //        };

            _controller.ModelState.AddModelError("problems",new Exception());

            //act
            var result = _controller.EditCustomer(new Customer());
            //assert
            Assert.AreEqual(HttpStatusCode.NoContent, result.StatusCode);
        }

        [TestMethod]
        public void EnsureAnEditedCustomerCanBeSavedWithAllRequiredFields()
        {
            ////arrange
            var CustomerToEdit =
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Taylor",
                        CustomerStreetAddress = "123 Update Street",
                        CustomerCity = "Awesomeville",
                        CustomerState = "TN",
                        CustomerZip = "37069",
                        CustomerPhone = "6158675309"
                    };

            //act
            var result = _controller.EditCustomer(CustomerToEdit);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
