using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWebstore.BusinessLayer.BusinessEntities;

namespace OnlineWebstore.BusinessLayer.ServiceInterface
{
    public interface IProductManagerService
    {
         List<ProductCategory> GetAllProductCategories();
        void AddProductCategory(BusinessEntities.ProductCategory newProductCategory);
        void DeleteProductCategory(BusinessEntities.ProductCategory ProductCategory);
        bool IsProductCategoryAvaialable(int productCategoryID);
        ProductCategory GetProductCategory(int productCategoryID);
        bool ModifyProductCategory(BusinessEntities.ProductCategory pc);

        #region Products
        List<Product> GetAllProducts();
        BusinessEntities.Product AddProduct(BusinessEntities.Product newProduct);
        void DeleteProduct(BusinessEntities.Product  Product);
        bool IsProductAvaialable(int productID);
        Product GetProduct(int productID);
        bool ModifyProduct(BusinessEntities.Product  pc);
        #endregion
    }
}
