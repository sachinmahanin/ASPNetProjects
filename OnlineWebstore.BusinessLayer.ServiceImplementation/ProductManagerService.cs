using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWebstore.BusinessLayer.BusinessEntities;
using OnlineWebstore.BusinessLayer.ServiceInterface;

namespace OnlineWebstore.BusinessLayer.ServiceImplementation
{
    public class ProductManagerService : IProductManagerService
    {
        public Product AddProduct(Product newProduct)
        {
            throw new NotImplementedException();
        }

        public void AddProductCategory(ProductCategory newProductCategory)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product Product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProductCategory(ProductCategory ProductCategory)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategory> GetAllProductCategories()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Product GetProduct(int productID)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetProductCategory(int productCategoryID)
        {
            throw new NotImplementedException();
        }

        public bool IsProductAvaialable(int productID)
        {
            throw new NotImplementedException();
        }

        public bool IsProductCategoryAvaialable(int productCategoryID)
        {
            throw new NotImplementedException();
        }

        public bool ModifyProduct(Product pc)
        {
            throw new NotImplementedException();
        }

        public bool ModifyProductCategory(ProductCategory pc)
        {
            throw new NotImplementedException();
        }
    }
}
