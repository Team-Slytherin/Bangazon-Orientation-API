using System;
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
    public class EditCustomer
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
        public void EditACustomerSuccessfully()
        {
            var customerToEdit = new Customer
            {
                CustomerName = "nathan_g_zal",
                CustomerStreetAddress = "123 Coder St.",
                CustomerCity = "Nashville",
                CustomerState = "TN",
                CustomerZip = "37217",
                CustomerPhone = "615-867-5309",
                CustomerId =  3
            };
        }
    }
}
