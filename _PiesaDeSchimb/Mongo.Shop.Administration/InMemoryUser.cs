using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace Mongo.Shop.Administration
{
    public class InMemoryUser : IUser
    {
        readonly List<User> users;
        private readonly IMongoCollection<User> dbUsers;

        public InMemoryUser()
        {
            MongoClient mongoClient = new MongoClient("mongodb+srv://andcoman:pass@afacerielectronice-vhflh.azure.mongodb.net/test?retryWrites=true&w=majority");
            IMongoDatabase mongoDatabase = mongoClient.GetDatabase("PiesaDeSchimb");
            dbUsers = mongoDatabase.GetCollection<User>("Users");
        }

        public User Add(User newUser)
        {
            dbUsers.InsertOne(newUser);
            return newUser;
        }

        public void Delete(User user)
        {
            dbUsers.DeleteOne(us => us.Id == user.Id);
        }

        public List<User> GetAll()
        {
            return dbUsers.Find(user => true).ToList();
        }

        public User GetById(string id)
        {
            return dbUsers.Find(users => users.Id == id).FirstOrDefault();
        }

        public long GetCountOfUsers()
        {
            return GetAll().Count;
        }

        public IEnumerable<User> GetProducts(string name)
        {
            throw new NotImplementedException();
        }

        public void Update(User userIn)
        {
            dbUsers.ReplaceOne(user => user.Id == userIn.Id, userIn);
        }
    }
}
