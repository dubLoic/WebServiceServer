using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite.MongoObjects
{
    public class Suggestion : MongoObject
    {
        public IdMedia IdMedia { get; set; }
        public string SuggestedBy { get; set; }
        public string SuggestedTo { get; set; }
    }
}
