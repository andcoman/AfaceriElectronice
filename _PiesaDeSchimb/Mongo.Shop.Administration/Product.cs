using System;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text;

namespace Mongo.Shop.Administration
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Brand")]
        [BsonRequired]
        public string Brand { get; set; }

        [BsonElement("Title")]
        [BsonRequired]
        public string Title { get; set; }

        [BsonElement("IsInStock")]
        [BsonRequired]
        public bool IsInStock { get; set; }

        [BsonElement("Description")]
        [BsonRequired]
        public string Description { get; set; }

        [BsonElement("Price")]
        [Display(Name = "Price(RON)")]
        [DisplayFormat(DataFormatString = "{0:#,0}")]
        public decimal Price { get; set; }

        [BsonElement("ImageUrl")]
        [Display(Name = "Photo")]
        [DataType(DataType.ImageUrl)]
        [BsonRequired]
        public string ImageUrl { get; set; }

        [BsonElement("HasDiscount")]
        [BsonRequired]
        public bool HasDiscount { get; set; }
    }
}
