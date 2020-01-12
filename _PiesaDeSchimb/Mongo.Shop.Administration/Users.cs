using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Shop.Administration
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("FirstName")]
        [BsonRequired]
        public string FirstName { get; set; }

        [BsonElement("LastName")]
        [BsonRequired]
        public string LastName { get; set; }

        [BsonElement("LastName")]
        [BsonRequired]
        public string Address { get; set; }

        [BsonElement("PhoneNumber")]
        [BsonRequired]
        public long PhoneNumber { get; set; }

        [BsonElement("Email")]
        [BsonRequired]
        public long Email { get; set; }

        [BsonElement("UserType")]
        [BsonRequired]
        public UserType UserType { get; set; }


    }
}
