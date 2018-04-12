﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWebstore.BusinessLayer.BusinessEntities;
using OnlineWebstore.BusinessLayer.ServiceInterface;
using OnlineWebstore.DAL;

namespace OnlineWebstore.BusinessLayer.ServiceImplementation
{
    public class ProductManagerService : IProductManagerService
    {
        DAL.DBEntityProvider db = new DBEntityProvider();
        
        BusinessEntities.Product IProductManagerService.AddProduct(BusinessEntities.Product newProduct)
        {
            OnlineWebstore.DAL.Product dbProduct = new DAL.Product();
            dbProduct.ProductName = newProduct.ProductName;
            dbProduct.ProductPrice = newProduct.ProductPrice;
            
            dbProduct.ProductCategoryId = newProduct.ProductCategoryId;
           
             
            db.AddNewProduct(dbProduct);
            return newProduct;
        }

        void IProductManagerService.AddProductCategory(BusinessEntities.ProductCategory newProductCategory)
        {
            throw new NotImplementedException();
        }

        void IProductManagerService.DeleteProduct(BusinessEntities.Product Product)
        {
            var dbProduct = new DAL.Product() { ProductID=Product.ProductID,
                                                ProductCategoryId=Product.ProductCategoryId,
                                                ProductName=Product.ProductName,
                                                ProductPrice =Product.ProductPrice
                                                };
           var isDeletionSucessful= db.DeleteProduct(dbProduct);
        }

        void IProductManagerService.DeleteProductCategory(BusinessEntities.ProductCategory ProductCategory)
        {
            throw new NotImplementedException();
        }

        List<BusinessEntities.ProductCategory> IProductManagerService.GetAllProductCategories()
        {
            var lstdbProductCategories = db.GetAllProductCategories();
            var lstProductCategories= lstdbProductCategories.Select(p => new BusinessEntities.ProductCategory() { CategoryName = p.CategoryName, ProductCategoryId = p.ProductCategoryId }).ToList();
            return lstProductCategories;
        }

        List<BusinessEntities.Product> IProductManagerService.GetAllProducts()
        {
           var lstProducts= db.GetAllProducts();

            // Convert DAL objects into Bussiness entities

          var lstBussinessProducts=  lstProducts.Select(p => new BusinessEntities.Product()
            {
                ProductCategoryId = p.ProductCategoryId,
                ProductID = p.ProductID
                                ,
                ProductName = p.ProductName,
                ProductPrice = p.ProductPrice
            }).ToList();

            return lstBussinessProducts;
        }

        BusinessEntities.Product IProductManagerService.GetProduct(int productID)
        {
            var dbProduct = db.GetProduct(productID);

            BusinessEntities.Product prd = new BusinessEntities.Product() { ProductCategoryId= dbProduct.ProductCategoryId,ProductID= dbProduct.ProductID,ProductName= dbProduct.ProductName,ProductPrice= dbProduct.ProductPrice};
            return prd;
        }

        BusinessEntities.ProductCategory IProductManagerService.GetProductCategory(int productCategoryID)
        {
            var dbProductCategory =db.GetProductCategory(productCategoryID);
            var productCategory = new BusinessEntities.ProductCategory() { ProductCategoryId=dbProductCategory.ProductCategoryId,CategoryName=dbProductCategory.CategoryName};
            return productCategory;

        }

        bool IProductManagerService.IsProductAvaialable(int productID)
        {
           var dbProductList= db.GetAllProducts();
           if(dbProductList!=null && dbProductList.Count > 0)
            {
              var dbProduct=  dbProductList.Find(p => p.ProductID == productID);
                if (dbProduct != null)
                    return true;
            }
            return false;
        }

        bool IProductManagerService.IsProductCategoryAvaialable(int productCategoryID)
        {
            throw new NotImplementedException();
        }

        bool IProductManagerService.ModifyProduct(BusinessEntities.Product pc)
        {
            DAL.Product dbProduct = new DAL.Product() { ProductID = pc.ProductID, ProductName = pc.ProductName, ProductPrice = pc.ProductPrice,ProductCategoryId=pc.ProductCategoryId };
            bool isSuccessful= db.ModifyProduct(dbProduct);
            return isSuccessful;
        }

        bool IProductManagerService.ModifyProductCategory(BusinessEntities.ProductCategory pc)
        {
            throw new NotImplementedException();
        }
    }
}
