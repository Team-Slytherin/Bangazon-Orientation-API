using System;
using BangazonOrientation.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BangazonOrientation.API.DAL.Repository;

namespace BangazonOrientation.API.Tests.ControllerTest
{
    [TestClass]
    public class LineItemControllerTest
    {

        LineItemsController _controller;
        Mock<LineItemsRepository> _mockedLineItemRepository;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    _mockedLineItemRepository = new Mock<ICustomerRepository>();

        //    _controller = new CustomerController(_mockedCustomerRepository.Object);
        //    _controller.Request = new HttpRequestMessage();
        //    _controller.Request.SetConfiguration(new HttpConfiguration());
        //}



        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
