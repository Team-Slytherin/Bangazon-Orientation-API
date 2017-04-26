using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BangazonOrientation.API.Interfaces;
using BangazonOrientation.API.Models;

namespace BangazonOrientation.API.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        [HttpPost]
        public HttpResponseMessage RegisterCustomer([FromBody]Customer customer)
        {
            if(!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request: Ensure All Fields Are Populated");
            }

            _customerRepository.AddNewCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{customerId}")]
        public HttpResponseMessage RetrieveCustomer(int customerId)
        {
            var customer = _customerRepository.GetSingleCustomer(customerId);

            if (customer == null)
            {
               return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Content: Customer Does Not Exist.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpGet]
        public HttpResponseMessage RetrieveAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers() as List<Customer>;

            if (customers == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Content: No Customers Available.");
            }

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpPut]
        //[Route("{customerId}")]
        public HttpResponseMessage EditCustomer([FromBody]Customer editingCustomer)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Content: Select a Valid Customer to Edit.");
            }

            _customerRepository.EditCustomer(editingCustomer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
