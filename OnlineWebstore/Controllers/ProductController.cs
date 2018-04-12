using OnlineWebstore.BusinessLayer.ServiceImplementation;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineWebstore.ViewModel;
namespace OnlineWebstore.Controllers
{
    public class ProductController : Controller
    {
        public ProductController(IProductManagerService prdManager)
        {
            this.productManager = prdManager;
        }

        IProductManagerService productManager;// = new ProductManagerService();
        // GET: Product
        public ActionResult Index()
        {
            var products = productManager.GetAllProducts();
            var lstProductCategory = productManager.GetAllProductCategories();

            var lstProductViewModel = products.Select(item => new ProductViewModel()
            {
                ProductID = item.ProductID,
                ProductName = item.ProductName,
                ProductPrice = item.ProductPrice,
                ProductCategoryId = item.ProductCategoryId,
                ProductCategoryName = lstProductCategory.Find(p => p.ProductCategoryId == item.ProductCategoryId).CategoryName

            }).ToList();


            return View(lstProductViewModel);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            var product = productManager.GetProduct(id);
            var productCategory = productManager.GetProductCategory(product.ProductCategoryId);

            ProductViewModel pvm = new ProductViewModel()
            {
                ProductCategoryId = product.ProductCategoryId,
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                ProductPrice = product.ProductPrice,
                ProductCategoryName = productCategory.CategoryName
            };
            return View(pvm);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            var product = new ProductViewModel();
            var lstProductCategory = productManager.GetAllProductCategories();



            List<SelectListItem> listProductCategoryItems = (from f in lstProductCategory
                                                             select new SelectListItem
                                                             {
                                                                 Text = f.CategoryName,
                                                                 Value = f.ProductCategoryId.ToString()
                                                             }).ToList();
            product.listProductCategoryItems = listProductCategoryItems;
            return View(product);
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(ProductViewModel productModel)
        {
            try
            {
                // TODO: Add insert logic here
                BusinessLayer.BusinessEntities.Product product = new BusinessLayer.BusinessEntities.Product()
                {
                    ProductCategoryId = productModel.ProductCategoryId,
                    ProductName = productModel.ProductName,
                    ProductPrice = productModel.ProductPrice
                };

                productManager.AddProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            var product = productManager.GetProduct(id);
            var lstProductCategory = productManager.GetAllProductCategories();

            List<SelectListItem> listProductCategoryItems = (from f in lstProductCategory
                                                             select new SelectListItem
                                                             {
                                                                 Text = f.CategoryName,
                                                                 Value = f.ProductCategoryId.ToString(),
                                                                 Selected = f.ProductCategoryId == product.ProductCategoryId ? true : false
                                                             }).ToList();
            ProductViewModel pvm = new ProductViewModel()
            {
                ProductCategoryId = product.ProductCategoryId,
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                ProductPrice = product.ProductPrice,
                listProductCategoryItems = listProductCategoryItems
            };
            return View(pvm);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(ProductViewModel productModel)
        {
            try
            {
                // TODO: Add update logic here
                BusinessLayer.BusinessEntities.Product product = new BusinessLayer.BusinessEntities.Product()
                {
                    ProductID = productModel.ProductID,
                    ProductCategoryId = productModel.ProductCategoryId,
                    ProductName = productModel.ProductName,
                    ProductPrice = productModel.ProductPrice
                };

                productManager.ModifyProduct(product);
                return RedirectToAction("Index");
            }
            catch
            {
                var lstProductCategory = productManager.GetAllProductCategories();

                List<SelectListItem> listProductCategoryItems = (from f in lstProductCategory
                                                                 select new SelectListItem
                                                                 {
                                                                     Text = f.CategoryName,
                                                                     Value = f.ProductCategoryId.ToString(),
                                                                     Selected = f.ProductCategoryId == productModel.ProductCategoryId ? true : false
                                                                 }).ToList();
                productModel.listProductCategoryItems = listProductCategoryItems;
                return View(productModel);
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productManager.GetProduct(id);
            var productCategory = productManager.GetProductCategory(product.ProductCategoryId);

             ProductViewModel pvm = new ProductViewModel()
            {
                ProductCategoryId = product.ProductCategoryId,
                ProductName = product.ProductName,
                ProductID = product.ProductID,
                ProductPrice = product.ProductPrice,
                ProductCategoryName = productCategory.CategoryName
            };
            return View(pvm);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here
                productManager.DeleteProduct(new BusinessLayer.BusinessEntities.Product() { ProductID =  id });
                return RedirectToAction("Index");
            }
            catch
            {
                var product = productManager.GetProduct(id);
                var productCategory = productManager.GetProductCategory(product.ProductCategoryId);

                ProductViewModel pvm = new ProductViewModel()
                {
                    ProductCategoryId = product.ProductCategoryId,
                    ProductName = product.ProductName,
                    ProductID = product.ProductID,
                    ProductPrice = product.ProductPrice,
                    ProductCategoryName = productCategory.CategoryName
                };
                return View(pvm);
            }
        }
    }
}
