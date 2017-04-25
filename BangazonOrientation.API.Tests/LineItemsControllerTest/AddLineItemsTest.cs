using System;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BangazonOrientation.API.Tests.LineItemsControllerTest
{
    [TestClass]
    public class AddLineItemsTest
    {

        LineItemsController _controller;
        Mock<ILineItemsRepository> _mockedLineItemRepository;

        [TestInitialize]
        public void Initialize()
        {
            _mockedLineItemRepository = new Mock<ILineItemsRepository>();

            _controller = new LineItemsController(_mockedLineItemRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }


        [TestMethod]
        public void AddLineItems()
        {

        }
    }
}
