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

        ///api/customer/1/cart/1/lineitems/1
        [HttpGet,Route("{lineitemId}")]
        public HttpResponseMessage GetLineItemById(int cartId)
        {
            var itemsInCart = _lineItemsRepository.GetLineItem(cartId);

            return Request.CreateResponse(HttpStatusCode.OK, itemsInCart);
        }

        [HttpGet, Route]
        public HttpResponseMessage GetAllLineItems()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut, Route]
        public HttpResponseMessage EditLineItem()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost, Route]
        public HttpResponseMessage AddLineItem(LineItem lineItem)
        {
            _lineItemsRepository.AddLineItem(lineItem);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
