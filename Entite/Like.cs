using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite
{
    public class Like
    {
        public IdMedia IdMedia { get; set; }
    }

    public class IdMedia
    {
        public int idMedia { get; set; }
        public int mediaType { get; set; }
    }
}
