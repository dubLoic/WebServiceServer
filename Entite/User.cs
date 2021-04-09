using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public Like[] likes { get; set; }
        public Suggestion[] suggestions { get; set; }
        public string userName { get; set; }


    }
}
