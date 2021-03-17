using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entite
{
    public class MediaResult
    {
        public int page { get; set; }
        public MediaDTO[] results { get; set; }
    }
}
