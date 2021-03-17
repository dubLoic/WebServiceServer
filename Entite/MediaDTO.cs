using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite
{
    public class MediaDTO
    {
        public int[] genre_ids { get; set; } = new int[] { };
        public int id { get; set; } = -1;
        public string media_type { get; set; } = "";
        public string name { get; set; } = "No title";
        public string overview { get; set; } = "...";
        public string original_name { get; set; } = "";
        public string poster_path { get; set; } = "";
    }
}
