using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite
{
    public class MediaDTO
    {
        public int[] genre_ids { get; set; }
        public int id { get; set; }
        public string media_type { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string original_title { get; set; }
        public string original_name { get; set; }
        public string poster_path { get; set; }

        public MediaDTO Format()
        {
            MediaDTO res = this;
            if (poster_path != null)
                res.poster_path = poster_path.Contains("https://image.tmdb.org/") ? poster_path : "https://image.tmdb.org/t/p/w500/" + poster_path;

            if (!string.IsNullOrEmpty(name)) res.title = name;
            if (!string.IsNullOrEmpty(original_name)) res.original_title = original_title;

            return res;
        }
    }
}
