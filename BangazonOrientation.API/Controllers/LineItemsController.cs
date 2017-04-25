using BangazonOrientation.API.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BangazonOrientation.API.Controllers
{
    [RoutePrefix("api/customer/{customerId}/cart/{cartId}")]
    public class LineItemsController : ApiController
    {
        readonly LineItemsRepository _lineItemsRepository;

        public LineItemsController(LineItemsRepository lineItemsRepository)
        {
            _lineItemsRepository = lineItemsRepository;
        }


        [HttpGet]
        public HttpResponseMessage GetAllLineItems()
        {

            //if (string.IsNullOrWhiteSpace(customer.UserName))
            //{
            //    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            //}

            //_lineItemsRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[HttpGet]
        //public HttpResponseMessage GetAll()
        //{
        //    var customers = _lineItemsRepository.GetAll();

        //    return Request.CreateResponse(HttpStatusCode.OK, customers);
        //}
    }
}
