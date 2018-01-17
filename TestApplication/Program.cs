using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineWebstore.BusinessLayer.ServiceImplementation;
using OnlineWebstore.BusinessLayer.ServiceInterface;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductManagerService ProductManagerService = new ProductManagerService();
            var result = ProductManagerService.GetAllProductCategories();
        }
    }
}
