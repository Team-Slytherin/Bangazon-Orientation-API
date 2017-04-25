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
        public HttpResponseMessage RegisterCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.CustomerName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request: Invalid Customer Name");
            }

            _customerRepository.AddNewCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{customerId}")]
        public HttpResponseMessage RetrieveCustomer(int customerId)
        {
            var customer = _customerRepository.GetSingleCustomer(customerId);

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }

        [HttpGet]
        public HttpResponseMessage RetrieveAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers();

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpPut]
        public HttpResponseMessage EditCustomer(Customer customer)
        {
            if (customer == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Content: Select a Valid Customer to Edit.");
            }

            _customerRepository.EditCustomer(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
