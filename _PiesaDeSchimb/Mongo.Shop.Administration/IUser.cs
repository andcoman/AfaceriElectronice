using System;
using System.Collections.Generic;
using System.Text;

namespace Mongo.Shop.Administration
{
    public interface IUser
    {
        IEnumerable<User> GetProducts(string name);
        List<User> GetAll();
        User GetById(string id);
        void Update(User userIn);
        User Add(User newUser);
        void Delete(User user);
        long GetCountOfUsers();
    }
}
