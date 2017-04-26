using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BangazonOrientation.API.Controllers;
using Moq;
using BangazonOrientation.API.Interfaces;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using BangazonOrientation.API.Models;

namespace BangazonOrientation.API.Tests
{
    [TestClass]
    public class CartControllerTests
    {
        CartController _controller;
        Mock<ICartRepository> _mockedCartRepository;
        Mock<ICustomerRepository> _mockedCustomerRepository;
        [TestInitialize]
        public void Initialize()
        {
            _mockedCartRepository = new Mock<ICartRepository>();
            _mockedCustomerRepository = new Mock<ICustomerRepository>();
            _controller = new CartController(_mockedCartRepository.Object, _mockedCustomerRepository.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());

        }

        [TestMethod]
        public void ICanAddCartWhenCustomerIdIsValidAndNoActiveCart()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(It.IsAny<int>())).Returns(new Customer());
            var customerId = 5;
            //act
            var result = _controller.RegisterCart(customerId);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            //cart gets saved to a repository
            _mockedCartRepository.Verify(x => x.AddCart(customerId));
        }

        [TestMethod]
        public void ICanNotAddCartWhenCustomerIdIsNotValid()
        {
            //arrange
            var customerId = 5;
            //act
            var result = _controller.RegisterCart(customerId);
            //assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void ICanNotAddCartWhenCustomerIdIsValidAndActivecatExist()
        {
            //arrange
            _mockedCartRepository.Setup(x => x.GetActiveCart(It.IsAny<int>())).Returns(new Cart());
            var customerId = 5;
            //act
            var result = _controller.RegisterCart(customerId);
            //assert
            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }

        [TestMethod]
        public void ICanGetOneActiveCartWhenCustomerIdIsValid()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(It.IsAny<int>())).Returns(new Customer());
            _mockedCartRepository.Setup(x => x.GetActiveCart(It.IsAny<int>()))
                .Returns(() => new Cart {CustomerId = 5});

            //act
            var result = _controller.GetActiveOne(5);

            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
            var content = result.Content as ObjectContent<Cart>;
            var returnValue = content.Value as Cart;
            Assert.AreEqual(5, returnValue.CustomerId);
        }

        [TestMethod]
        public void ICanUpdatePaymentInfoWhenCustomerIdIsValid()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(It.IsAny<int>())).Returns(new Customer());
            var customerId = 5;
            var cart = new Cart
            {
                CartId = 5,
                PaymentId = 3
            };
            //act
            var result = _controller.EditPaymentInfo(customerId, cart);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void ICanEmptyCartWhenCustomerIdIsValid()
        {
            //arrange
            _mockedCustomerRepository.Setup(x => x.GetSingleCustomer(It.IsAny<int>())).Returns(new Customer());
            _mockedCartRepository.Setup(x => x.GetActiveCart(It.IsAny<int>())).Returns(new Cart());
            var customerId = 5;
            //act
            var result = _controller.EmptyCart(customerId);
            //assert
            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }
    }
}
