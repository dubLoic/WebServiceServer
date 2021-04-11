using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite.MongoObjects
{
    public class User : MongoObject
    {
        public Like[] likes { get; set; }
        public Suggestion[] suggestions { get; set; }
        public string userName { get; set; }


    }
}
