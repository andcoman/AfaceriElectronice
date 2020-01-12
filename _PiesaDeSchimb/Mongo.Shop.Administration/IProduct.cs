using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo.Shop.Administration
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts(string name);
        List<Product> GetAll();
        Product GetById(string id);
        void Update(Product productIn);
        Product Add(Product newProduct);
        void Delete(Product product);
        long GetCountOfProducts();
        IList<Product> GetDiscountProducts();
    }
}
