using System;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BangazonOrientation.API.Models;
using System.Net;

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
            //arrange 
            var newLineItem = new LineItem
            {
                LineItemDetailId = 1,
                LineItemId = 1,
                ProductId = 1,
                Qty = 1
            };
            _mockedLineItemRepository.Setup(x => x.AddLineItem(It.IsAny<LineItem>())).Returns(true);

            //act
            var result = _controller.AddLineItem(newLineItem);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //lineitem saved to repo
            _mockedLineItemRepository.Verify(x => x.AddLineItem(newLineItem), Times.Once);
        }

        // not working correctly....
        [TestMethod]
        public void AddLineItemsWithInvalidLineItemId()
        {
            //arrange 
            var newLineItem = new LineItem
            {
                LineItemDetailId = 26,
                LineItemId = 21,
                ProductId = 0,
                Qty = 12345
            };
            _mockedLineItemRepository.Setup(x => x.AddLineItem(It.IsAny<LineItem>())).Returns(false);

            //act
            var result = _controller.AddLineItem(newLineItem);

            //assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
            //lineitem saved to repo
            _mockedLineItemRepository.Verify(x => x.AddLineItem(newLineItem), Times.Once);
        }
    }
}
