using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using appentity;

namespace app.data
{
    public class ProductData
    {
        private List<Product> products;

        public ProductData()
        {
            products = new List<Product>
            {
                new Product { ProductId = 1, Name = "Laptop", Price = 1000,Description="sdasdsadsadsad" },
                new Product { ProductId = 2, Name = "Phone", Price = 500 }
            };
        }

        public List<Product> GetAllProducts()
        {
            return products;
        }

        public void AddProduct(Product product)
        {
            product.ProductId = products.Count + 1;
            products.Add(product);
        }
    }
}
}
