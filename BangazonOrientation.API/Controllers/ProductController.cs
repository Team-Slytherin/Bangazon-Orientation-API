using BangazonOrientation.API.Interfaces;
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

        [HttpGet]
        //get one product
        //pass in ProductID

        [HttpGet]
        //get all products
        //

        [HttpPost]
        //add new product
        //pass in Product Object 

        [HttpPut]
        //edit product details
        //pass in Product Object
    }
}
