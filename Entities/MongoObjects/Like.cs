using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entities.MongoObjects
{
    public class Like : MongoObject
    {
        public IdMedia IdMedia { get; set; }
        public string LikedBy { get; set; }
    }
}
