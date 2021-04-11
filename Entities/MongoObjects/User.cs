using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entities.MongoObjects
{
    public class User : MongoObject
    {
        public string Username { get; set; }


    }
}
