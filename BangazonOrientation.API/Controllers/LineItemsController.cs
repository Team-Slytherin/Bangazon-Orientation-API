using BangazonOrientation.API.DAL.Repository;
using BangazonOrientation.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Interfaces.Repository;

namespace BangazonOrientation.API.Controllers
{
    [RoutePrefix("api/customer/{customerid}/cart/{cartid}/lineitems")]
    public class LineItemsController : ApiController
    {
        readonly ILineItemsRepository _lineItemsRepository;

        public LineItemsController(ILineItemsRepository lineItemsRepository)
        {
            _lineItemsRepository = lineItemsRepository;
        }

        //api/customer/1/cart/1/lineitems/1
        [HttpGet,Route("{lineitemId}")]
        public HttpResponseMessage GetLineItemById(int lineItemId)
        {
            var result = _lineItemsRepository.GetLineItem(lineItemId);

            if (result == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Sorry LineItemId {lineItemId} does not exist.");

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        //api/customer/1/cart/1/lineitems
        [HttpGet, Route]
        public HttpResponseMessage GetAllLineItems(int cartId)
        {
            // Check for cart is not null
            var result = _lineItemsRepository.GetAllLineItemsInCart(cartId);

            if (result.Count == 0 || result == null)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Sorry There are no Carts with id of {cartId}");

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut, Route]
        public HttpResponseMessage EditLineItem(LineItem lineItem)
        {
            var result = _lineItemsRepository.EditLineItem(lineItem);

            if (!result)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Sorry LineItem {lineItem.LineItemDetailId} does not exist.");

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, Route]
        public HttpResponseMessage AddLineItem(LineItem lineItem)
        {
            var result = _lineItemsRepository.AddLineItem(lineItem);

            if (!result)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    $"Please enter numbers only for Qty, ProductId and LineItemId");
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        public bool ValidateLineItem(LineItem lineItem)
        {
            return lineItem.LineItemId != 0 && lineItem.ProductId != 0 && lineItem.Qty != 0;
        }
    }
}
