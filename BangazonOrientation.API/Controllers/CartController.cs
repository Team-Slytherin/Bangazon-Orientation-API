using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;
﻿using BangazonOrientation.API.DAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
        readonly ICustomerRepository _customerRepository;
        public CartController(ICartRepository cartRepository, ICustomerRepository customerRepository)
        {
            _cartRepository = cartRepository;
            _customerRepository = customerRepository;
        }

        public bool IsCustomerIdValid(int customerId)
        {
            if (_customerRepository.GetSingleCustomer(customerId) != null) return true;
            return false;
        }

        [HttpPost]
        [Route]
        public HttpResponseMessage RegisterCart(int customerId)
        {
            if (!IsCustomerIdValid(customerId))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CustomerId");
            if (_cartRepository.GetActiveCart(customerId) != null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Cart already exist.");
            _cartRepository.AddCart(customerId);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route]
        public HttpResponseMessage GetActiveOne(int customerId)
        {
            if (IsCustomerIdValid(customerId))
            {
                var cart = _cartRepository.GetActiveCart(customerId);
                return Request.CreateResponse(HttpStatusCode.OK, cart);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CustomerId");
        }

        [HttpPut]
        [Route]
        public HttpResponseMessage EditPaymentInfo(int customerId, [FromBody]Cart editedCart)
        {
            if (!IsCustomerIdValid(customerId))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CustomerId");

            _cartRepository.EditCartStatus(customerId, editedCart);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route]
        public HttpResponseMessage EmptyCart(int customerId)
        {
            if (!IsCustomerIdValid(customerId))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CustomerId");

            if (_cartRepository.GetActiveCart(customerId) == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No active cart exists.");

            _cartRepository.EmptyCart(customerId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
