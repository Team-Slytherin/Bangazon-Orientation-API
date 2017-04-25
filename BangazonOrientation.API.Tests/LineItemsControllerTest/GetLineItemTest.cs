using System;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BangazonOrientation.API.DAL.Repository;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Interfaces.Repository;
using System.Net;

namespace BangazonOrientation.API.Tests.LineItemsControllerTest
{
    [TestClass]
    public class LineItemControllerTest
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
        public void GetLineItemById()
        {
            //arrange
            int lineItemDetailsId = 1;

            //act
            var result = _controller.GetLineItemById(lineItemDetailsId);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
