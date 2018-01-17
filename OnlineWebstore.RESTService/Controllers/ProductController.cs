using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineWebstore.BusinessLayer.BusinessEntities;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using OnlineWebstore.BusinessLayer.ServiceImplementation;
using System.Web.Http.Description;

namespace OnlineWebstore.RESTService.Controllers
{
 
    public class ProductController : ApiController
    {
         IProductManagerService projectManager = new  ProductManagerService();
         
        [ResponseType(typeof(Product))]
        [HttpGet]
        public IHttpActionResult Get(string ProductId)
        {

            int id = 0;
            if (string.IsNullOrEmpty(ProductId))
                return   BadRequest("Product Id can't be empty" );
            try
            {
               id=Convert.ToInt32(ProductId);
             }
            catch
            {
                return BadRequest("Product Id can't be empty");

            }
            var product =projectManager.GetProduct(id);
            if(product==null)
                 return NotFound();
            return Ok(product);
        }

    }
}
