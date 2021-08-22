using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQExample
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Category> categories = new List<Category>() {
             new Category{CategoryId=1,CategoryName="Computer"},
             new Category{CategoryId=2,CategoryName="Phone"}
            };

            List<Product> products = new List<Product>()
            {
                new Product{Id=1,CategoryId=1,ProductName = "Acer Laptop",QuantityPerUnit="32 GB Ram",UnitPrice=10000,UnitInStock=5},
                new Product{Id=2,CategoryId=1,ProductName = "Asus Laptop",QuantityPerUnit="16 GB Ram",UnitPrice=8000,UnitInStock=3},
                new Product{Id=3,CategoryId=1,ProductName = "HP Laptop",QuantityPerUnit="8 GB Ram",UnitPrice=8000,UnitInStock=2},
                new Product{Id=4,CategoryId=2,ProductName = "Samsung Phone",QuantityPerUnit="4 GB Ram",UnitPrice=5000,UnitInStock=15},
                new Product{Id=5,CategoryId=2,ProductName = "Apple Phone",QuantityPerUnit="4 GB Ram",UnitPrice=15000,UnitInStock=0}
            };

           
             
            //Any(products);
            //Find(products);
            //FindAll(products);
            //OrderBy(products); 
            //OrderByDescending(products);
            //FindAllContainsOrderBy(products);
            //PriceRange(products);
            //OrderByAndThenBy(products);
            //ClassicLinqText(products);
            //JoinCategory(categories, products);
        }
        #region
        private static void JoinCategory(List<Category> categories, List<Product> products)
        {
            var result = from p in products
                         join c in categories
                         on p.CategoryId equals c.CategoryId
                         where p.UnitPrice > 5000
                         orderby p.UnitPrice descending // A-Z
                         select new ProductDto { ProductId = p.Id, CategoryName = c.CategoryName, ProductName = p.ProductName, UnitPrice = p.UnitPrice };
            foreach (var item in result)
            {
                Console.WriteLine("{0} --- {1}", item.ProductName, item.CategoryName);
            }
        }

        private static void FromExample(List<Product> products)
        {
            var result = from p in products
                         where p.UnitPrice > 6000 && p.CategoryId == 1
                         orderby p.UnitPrice descending, p.ProductName ascending
                         select new ProductDto {ProductId=p.Id,ProductName=p.ProductName,UnitPrice=p.UnitPrice};
            Console.WriteLine( result);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void NewMethod(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("Laptop") || p.CategoryId == 1).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
            foreach (var item in result) { Console.WriteLine(item.ProductName); }
        }

        private static void PriceRange(List<Product> products)
        {
            decimal max = 8000, min = 4000;
            var result = products.Where(p => p.UnitPrice <= 8000 && p.UnitPrice >= 4000);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void FindAllContainsOrderBy(List<Product> products)
        {
            var result = products.FindAll(p => p.CategoryId == 2).OrderBy(p => p.ProductName);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void OrderByDescending(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice);
            foreach (var item in result) { Console.WriteLine(item.ProductName); }
        }

        private static void OrderBy(List<Product> products)
        {
            var result = products.Where(p => p.ProductName.Contains("top")).OrderBy(p => p.UnitPrice);
            foreach (var item in result)
            {
                Console.WriteLine(item.ProductName);
            }
        }

        private static void FindAll(List<Product> products)
        {
            var result = products.FindAll(p => p.ProductName.Contains("top"));
            Console.WriteLine(result);
        }

        private static void Find(List<Product> products)
        {
            var result = products.Find(p => p.Id == 100);
            Console.WriteLine(result.ProductName);
        }

        private static void Any(List<Product> products)
        {
            var result = products.Any(p => p.ProductName == "Acer Lapto");
            Console.WriteLine(result);
        }
        #endregion
    }
}
