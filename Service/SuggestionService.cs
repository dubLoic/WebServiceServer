using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entities;
using WebserviceServer.Entities.MongoObjects;

namespace WebserviceServer.Service
{
    public class SuggestionService
    {
        private readonly IMongoCollection<Suggestion> _suggestions;
        public SuggestionService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _suggestions = database.GetCollection<Suggestion>(settings.SuggestionCollectionName);

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

        public List<Suggestion> GetSuggestionsForSelectedMedia(int id, int type, string suggestedTo) =>
            _suggestions.Find(suggestion => (suggestion.IdMedia.mediaType == type &&
                                             suggestion.IdMedia.idMedia == id &&
                                             suggestion.SuggestedTo == suggestedTo)).ToList();


        public bool Create(Suggestion toCreate)
        {
            if (Get(toCreate) == null)
            {
                _suggestions.InsertOne(toCreate);
                return true;
            }
            else
            {
                Remove(toCreate.IdMedia.idMedia, toCreate.IdMedia.mediaType, toCreate.SuggestedBy, toCreate.SuggestedTo);
                return false;
            }
        }

        public void Remove(int id, int type, string suggestedBy, string suggestedTo) =>
          _suggestions.DeleteOne(
                  suggestion => (suggestion.IdMedia.mediaType == type &&
                                 suggestion.IdMedia.idMedia == id &&
                                 suggestion.SuggestedBy == suggestedBy &&
                                 suggestion.SuggestedTo == suggestedTo));
    }
}

