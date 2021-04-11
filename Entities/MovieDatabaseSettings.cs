using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebserviceServer.Entities
{
    public class MovieDatabaseSettings : IMovieDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string LikeCollectionName { get; set; }
        public string SuggestionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMovieDatabaseSettings
    {
        public string UserCollectionName { get; set; }
        public string LikeCollectionName { get; set; }
        public string SuggestionCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
