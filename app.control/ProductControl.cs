using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using app.data;
using appentity;



namespace app.control
{
    public class ProductControl
    {
        private ProductData productData;

        public ProductControl()
        {
            productData = new ProductData();
        }

        public List<Product> GetProducts()
        {
            return productData.GetAllProducts();
        }

        public void AddProduct(Product product)
        {
            productData.AddProduct(product);
        }
    }
}
