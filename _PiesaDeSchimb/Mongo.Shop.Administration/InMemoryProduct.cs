using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Mongo.Shop.Administration
{
    

    public class InMemoryProduct : IProduct
    {
        readonly List<Product> products;
        private readonly IMongoCollection<Product> dbProducts;

        public InMemoryProduct()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://andcoman:pass@afacerielectronice-vhflh.azure.mongodb.net/test?retryWrites=true&w=majority");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("PiesaDeSchimb");            
            dbProducts = mongoDatabase.GetCollection<Product>("Product");
        }
      
        public List<Product> GetAll()
        {
            return dbProducts.Find(product => true).ToList();
        }

        public Product Add(Product newProduct)
        {
            dbProducts.InsertOne(newProduct);
            return newProduct;
        }

        public void Delete(Product product)
        {
            dbProducts.DeleteOne(prod => prod.Id == product.Id);
        }

        public Product GetById(string id)
        {
            return dbProducts.Find(product => product.Id == id).FirstOrDefault();
        }

        public long GetCountOfProducts()
        {
            return GetAll().Count;
        }

        public IEnumerable<Product> GetProducts(string name)
        {
            return dbProducts.Find(product => true) as IEnumerable<Product>;
        }

        public void Update(Product productIn)
        {
            dbProducts.ReplaceOne(product => product.Id == productIn.Id, productIn);
        }
        public IList<Product> GetDiscountProducts()
        {
            return dbProducts.Find(product => product.HasDiscount == true) as IList<Product>;
        }
    }
}
