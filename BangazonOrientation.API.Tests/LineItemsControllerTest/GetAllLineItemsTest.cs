using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Controllers;
using BangazonOrientation.API.Interfaces.Repository;
using BangazonOrientation.API.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BangazonOrientation.API.Tests.LineItemsControllerTest
{
    [TestClass]
    public class GetAllLineItemsTest
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
        public void GetAllLineItemsFromDb()
        {
            //arrange 
            var newLineItem = new LineItem
            {
                LineItemDetailId = 26,
                LineItemId = 21,
                ProductId = 2,
                Qty = 12345
            };

            //act
            var expectedResult = _controller.AddLineItem(newLineItem);
            var result = _controller.GetAllLineItems(21);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, expectedResult.StatusCode);
            //lineitem saved to repo
            _mockedLineItemRepository.Verify(x => x.AddLineItem(newLineItem), Times.Once);
            //lineitem retrieved from repo
            _mockedLineItemRepository.Verify(x => x.GetAllLineItemsInCart(21), Times.Once);
        }
    }
}
