using BangazonOrientation.API.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.API.Controllers
{
    [RoutePrefix("api/customer/{customerid}/cart/{cartid}/lineitems")]
    public class LineItemsController : ApiController
    {
        readonly LineItemsRepository _lineItemsRepository;

        public LineItemsController(LineItemsRepository lineItemsRepository)
        {
            _lineItemsRepository = lineItemsRepository;
        }


        [HttpGet,Route("{lineitemId}")]
        public HttpResponseMessage GetLineItemById()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
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

        [HttpPost, Route]
        public HttpResponseMessage EditLineItem()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut, Route]
        public HttpResponseMessage AddLineItem()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
