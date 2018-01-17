﻿using OnlineWebstore.BusinessLayer.BusinessEntities;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace OnlineWebstore.Controllers.WebAPI
{
    public class ProductController : ApiController
    {
        IProductManagerService productManager = new BusinessLayer.ServiceImplementation.ProductManagerService();
        //GET: api/Product
       [ResponseType(typeof(IEnumerable<BusinessLayer.BusinessEntities.Product>))]
       [HttpGet]
        public IHttpActionResult Get()
        {
            var lstProducts = productManager.GetAllProducts();
            return Ok(lstProducts);
        }

        // GET: api/Product/5
        [ResponseType(typeof(BusinessLayer.BusinessEntities.Product))]
        [HttpGet]
         public IHttpActionResult Get(int id)
        {

            //int id = 0;
            //if (string.IsNullOrEmpty(ProductId))
            //    return BadRequest("Product Id can't be empty");
            //try
            //{
            //    id = Convert.ToInt32(ProductId);
            //}
            //catch
            //{
            //    return BadRequest("Product Id can't be empty");

            //}
            try
            {
                var product = productManager.GetProduct(id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch(Exception ex)
            {
                return   InternalServerError(ex);
            }
        }

        // POST: api/Product
        [HttpPost]
        public IHttpActionResult Post([FromBody]Product newProduct )
        {
            try
            {
                if (newProduct == null)
                    return BadRequest();
                if (ModelState.IsValid)
                {
                    Product product = productManager.AddProduct(newProduct);
                    return CreatedAtRoute("DefaultApi", new { id = product.ProductID }, product);
                }
                else
                    return BadRequest(ModelState);
                     
            }
             catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT: api/Product/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Product/5
        public void Delete(int id)
        {
        }
    }
}
