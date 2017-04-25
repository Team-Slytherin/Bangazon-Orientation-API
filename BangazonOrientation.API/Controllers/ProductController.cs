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
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet] //get one product //pass in ProductID
        [Route("/{productId}")]
        public HttpResponseMessage GetOneProduct(int productId)
        {
            var product = _productRepository.GetOneProduct(productId);
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        [HttpGet] //get all products
        public HttpResponseMessage GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();
            return Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [HttpPost]//add new product ////pass in Product Object
        public HttpResponseMessage AddNewProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid entry.");
            }
            _productRepository.AddProduct(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]//edit product details //pass in Product Object
        public HttpResponseMessage EditOneProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Content. Please select a valid product to update.");
            }

            _productRepository.UpdateProduct(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
