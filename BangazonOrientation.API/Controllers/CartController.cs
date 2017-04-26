using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.API.Controllers
{
    [RoutePrefix("api/customer/{customerId}/cart")]
    public class CartController : ApiController
    {
        readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage RegisterCart(int customerId)
        {
            _cartRepository.AddCart(customerId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage GetActiveOne(int customerId)
        {
            var cart = _cartRepository.GetActiveCart(customerId);

            return Request.CreateResponse(HttpStatusCode.OK, cart);
        }

        [HttpPut]
        [Route]
        public HttpResponseMessage EditPaymentInfo(Cart cart)
        {
             _cartRepository.EditCartStatus(cart);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route]
        public HttpResponseMessage EmptyCart(int customerId)
        {
            _cartRepository.EmptyCart(customerId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
