using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineWebstore.BusinessLayer.ServiceImplementation;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using OnlineWebstore.BusinessLayer.BusinessEntities;
using OnlineWebstore.ViewModel;
namespace OnlineWebstore.Controllers
{
    public class ProductCategoriesController : Controller
    {

        public ProductCategoriesController(IProductManagerService prdManager)
        {
            this.productManager = prdManager;
        }
        IProductManagerService productManager;
        
        // GET: ProductCategories
        public ActionResult Index()
        {
            var productCategories = productManager.GetAllProductCategories();
            return View(productCategories.ToList());
        }

  
        // GET: ProductCategories/Create
        public ActionResult Create()
        {
            ProductCategory productCategory = new ProductCategory();

            return View(productCategory);
        }

        //// POST: ProductCategories/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductCategoryId,CategoryName")] ProductCategory productCategory)
        {

            try
            {
                productManager.AddProductCategory(productCategory);

                return RedirectToAction("Index");

            }
            catch(Exception ex)
            {
                throw ex;
            }
            
             
        }

        //// GET: ProductCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bool isAvailable = productManager.IsProductCategoryAvaialable(Convert.ToInt32(id));
            if (isAvailable == false)
            {
                return HttpNotFound();
            }
            var productCategory = productManager.GetProductCategory(Convert.ToInt32(id));
            if (productCategory == null)
            {
                return HttpNotFound();
            }

            return View(productCategory);
        }

        //// POST: ProductCategories/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductCategoryId,CategoryName")] ProductCategory productCategory)
        {
            bool success=productManager.ModifyProductCategory(productCategory);
            if (success == true)
            {
                return RedirectToAction("Index");
            }
            return View(productCategory);
        }

        //// GET: ProductCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bool isAvailable = productManager.IsProductCategoryAvaialable(Convert.ToInt32( id));
            if (isAvailable == false)
            {
                return HttpNotFound();
            }
            var productCategory = productManager.GetProductCategory(Convert.ToInt32(id));
            if(productCategory==null)
            {
                return HttpNotFound();
            }
            return View(productCategory);
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductCategory productCategory = new ProductCategory() { ProductCategoryId = Convert.ToInt32(id) };
            productManager.DeleteProductCategory(productCategory);
            return RedirectToAction("Index");
        }

    }
}
