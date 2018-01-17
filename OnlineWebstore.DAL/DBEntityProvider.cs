using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineWebstore.DAL
{
    public class DBEntityProvider
    {


        #region User
        public int Authenticate(User user)
        {
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {

                OnlineWebstore.DAL.User dbUser = db.Users.Where(u => u.UserName==user.UserName && u.Password==user.Password).FirstOrDefault();
                if (dbUser == null)
                    return 0;
                else
                    return dbUser.UserId;
            }

        }
        #endregion

        #region Product 
        public bool IsProductAvaialable(int productID)
        {
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {
              
                Product fetchedProduct = db.Products.Find(productID);
                if (fetchedProduct == null)
                    return false;
                else
                    return true;
            }
        }
        public Product AddNewProduct (Product pc)
        {
            try
            {
                using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                {
                    db.Products.Add(pc);
                    db.Entry(pc).State = EntityState.Added;
                    db.SaveChanges();
                    int id = pc.ProductID;

                    Product newProduct=db.Products.Find(id);
                    if (newProduct == null)
                        throw new Exception("Not able to create the Produect");
                    return newProduct;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Product> GetAllProducts()
        {
            List<Product> lstProduct  = default(List<Product>);
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {
                lstProduct = db.Products.ToList();
                return lstProduct;
            }
        }
        public Product GetProduct(int productID)
        {
            try
            {
                using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                {
                    Product fetchedProduct = db.Products.Find(productID);
                    return fetchedProduct;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool DeleteProduct (Product  pc)
        {
            try
            {
                using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                {
                    db.Products.Add(pc);
                    db.Entry(pc).State = EntityState.Deleted;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ModifyProduct(Product pc)
        {
            try
            {
                using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                {
         
                    if (pc != null)
                    {
                        db.Entry(pc).State = EntityState.Modified;
                        db.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region ProductCategory
        public  List<ProductCategory> GetAllProductCategories()
        {
            List<ProductCategory> lstProductCategories = default(List<ProductCategory>);
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {
                lstProductCategories = db.ProductCategories.ToList();
                return lstProductCategories;
            }
         }
        public bool AddNewProductCategory(ProductCategory pc)
        {
            try
            {
                using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                {
                    db.ProductCategories.Add(pc);
                    db.Entry(pc).State = EntityState.Added;
                    db.SaveChanges();
                    return true;
                }
            }
            catch( Exception ex)
            {
                throw ex;
            }
            
        }
        public bool IsProductCategoryAvaialable(int productCategoryID)
        {
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {
                ProductCategory fetchedProductCategory = db.ProductCategories.Find(productCategoryID);
                 if (fetchedProductCategory == null)
                    return false;
                 else
                return true;
            }
 
        }
        public ProductCategory GetProductCategory(int productCategoryID)
        {
            using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
            {
                ProductCategory fetchedProductCategory = db.ProductCategories.Find(productCategoryID);
                return fetchedProductCategory;

            }
        }
        public bool DeleteProductCategory(ProductCategory pc)
            {
                try
                {
                    using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                    {
                        db.ProductCategories.Add(pc);
                        db.Entry(pc).State = EntityState.Deleted;
                        db.SaveChanges();
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        public bool ModifyProductCategory(ProductCategory pc)
            {
                try
                {
                    using (OnlineShoppingStoreEntities db = new OnlineShoppingStoreEntities())
                    {
                    ProductCategory fetchedProductCategory = db.ProductCategories
                        .Where(b => b.ProductCategoryId == pc.ProductCategoryId).FirstOrDefault();

                        if (fetchedProductCategory != null)
                        {
                            db.Entry(fetchedProductCategory).State = EntityState.Modified;
                            db.SaveChanges();
                            return true;
                        }

                        return false;
                    }
                }
                catch (Exception ex)
                {
                   throw ex;
                }

            }
        #endregion
    }
}
