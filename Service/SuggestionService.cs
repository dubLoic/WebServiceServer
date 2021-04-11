using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entite;
using WebserviceServer.Entite.MongoObjects;

namespace WebserviceServer.Service
{
    public class SuggestionService
    {
        private readonly IMongoCollection<Suggestion> _suggestions;
        public SuggestionService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _suggestions = database.GetCollection<Suggestion>(settings.UserCollectionName);

        }

        public List<Suggestion> Get()
        {
            List<Suggestion> suggestions;
            suggestions = _suggestions.Find(suggestion => true).ToList();
            return suggestions;
        }

        public Suggestion Get(Suggestion toGet) =>
            _suggestions.Find(suggestion => (suggestion.IdMedia.mediaType == toGet.IdMedia.mediaType && 
                                             suggestion.IdMedia.idMedia == toGet.IdMedia.idMedia &&
                                             suggestion.SuggestedBy == toGet.SuggestedBy &&
                                             suggestion.SuggestedTo == toGet.SuggestedTo)).FirstOrDefault();

        public Suggestion Create(Suggestion toCreate)
        {
            _suggestions.InsertOne(toCreate);
            return toCreate;
        }

        public void Update(Suggestion toUpdate)
        {
            Suggestion sugg = Get(toUpdate);
            if (sugg != null)
                Remove(sugg);
            else
                Create(sugg);
        }

        public void Remove(Suggestion toRemove) =>
            _suggestions.DeleteOne(suggestion => (suggestion == toRemove));
            //_suggestions.DeleteOne(
            //    suggestion => (suggestion.IdMedia.mediaType == toRemove.IdMedia.mediaType && 
            //                   suggestion.IdMedia.idMedia == toRemove.IdMedia.idMedia &&
            //                   suggestion.SuggestedBy == toRemove.SuggestedBy &&
            //                   suggestion.SuggestedTo == toRemove.SuggestedTo));


    }
}

