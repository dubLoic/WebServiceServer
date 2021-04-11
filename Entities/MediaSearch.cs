using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entities
{
    public class MediaSearch
    {
        public int mediaType { get; set; }
        public string text { get; set; }
        public string genre { get; set; }
    }
}
