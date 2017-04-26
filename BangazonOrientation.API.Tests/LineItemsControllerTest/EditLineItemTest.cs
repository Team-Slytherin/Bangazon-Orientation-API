using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces.Repository;
using BangazonOrientation.API.Models;
using Moq;

namespace BangazonOrientation.API.Tests.LineItemsControllerTest
{
    [TestClass]
    public class EditLineItemTest
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
        public void EditLineItems()
        {
            //arrange 
            var edittedLineItem = new LineItem
            {
                LineItemDetailId = 26,
                LineItemId = 21,
                ProductId = 2,
                Qty = 123456
            };
            _mockedLineItemRepository.Setup(x => x.EditLineItem(It.IsAny<LineItem>())).Returns(true);

            //act
            var result = _controller.EditLineItem(edittedLineItem);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //mock lineitem saved to repo
            _mockedLineItemRepository.Verify(x => x.EditLineItem(edittedLineItem), Times.Once);
        }

    }
}
