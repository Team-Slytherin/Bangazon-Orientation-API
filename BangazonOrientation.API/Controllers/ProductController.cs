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
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet] //get one product //pass in ProductID
        [Route("productId")]
        public HttpResponseMessage GetOneProduct(int productId)
        {
            throw new NotImplementedException();
        }

        [HttpGet] //get all products
        [Route("all")]
        public HttpResponseMessage GetAllProducts()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("new/success")]
        //add new product
        ////pass in Product Object 
        public HttpResponseMessage AddNewProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid entry.");
            }
            _productRepository.AddProduct(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        //edit product details
        //pass in Product Object
    }
}
