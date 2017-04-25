using BangazonOrientation.API.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.API.Controllers
{
    public class CartController : ApiController
    {
        readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost]
        [Route("api/cart/{customerId}")]
        public HttpResponseMessage RegisterCart(int customerId)
        {
            _cartRepository.AddCart(customerId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/cart/{customerId}")]
        public HttpResponseMessage GetActiveOne(int customerId)
        {
            var cart = _cartRepository.GetActiveCart(customerId);

            return Request.CreateResponse(HttpStatusCode.OK, cart);
        }

        [HttpPut]
        [Route("api/cart/payment/{paymentId}")]
        public HttpResponseMessage EditPaymentInfo(int cartId, int paymentId)
        {
             _cartRepository.EditCartStatus(cartId, paymentId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/cart/editcart/{cartId}/{paymentId}")]
        public HttpResponseMessage EditOrderStatus(int cartId, int paymentId)
        {
            _cartRepository.EditCartStatus(cartId, paymentId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("api/cart/emptycart/{customerId}")]
        public HttpResponseMessage EmptyCart(int customerId)
        {
            _cartRepository.EmptyCart(customerId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
