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
            var lineItem = _lineItemsRepository.GetLineItem(lineItemId);

            return Request.CreateResponse(HttpStatusCode.OK, lineItem);
        }

        //api/customer/1/cart/1/lineitems
        [HttpGet, Route]
        public HttpResponseMessage GetAllLineItems(int cartId)
        {

            var result = _lineItemsRepository.GetAllLineItemsInCart(cartId);

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPut, Route]
        public HttpResponseMessage EditLineItem(LineItem lineItem)
        {
            var result = _lineItemsRepository.EditLineItem(lineItem);
            return Request.CreateResponse(result ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
        }

        [HttpPost, Route]
        public HttpResponseMessage AddLineItem(LineItem lineItem)
        {
            _lineItemsRepository.AddLineItem(lineItem);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
