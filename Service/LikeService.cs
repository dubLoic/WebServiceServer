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
    public class LikeService
    {
        private readonly IMongoCollection<Like> _likes;
        public LikeService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _likes = database.GetCollection<Like>(settings.LikeCollectionName);

        }

        public List<Like> Get()
        {
            List<Like> likes;
            likes = _likes.Find(like => true).ToList();
            return likes;
        }

        public List<Like> GetLikesForSelectedMedia(int id, int type) =>
            _likes.Find(like => (like.IdMedia.mediaType == type &&
                                 like.IdMedia.idMedia == id)).ToList();

        //public Like Get(Like tempLike)
        //{
        //    var filter = Builders<Like>.Filter.And(
        //        Builders<Like>.Filter.Eq("IdMedia.mediaType", tempLike.IdMedia.mediaType),
        //        Builders<Like>.Filter.Eq("IdMedia.idMedia", tempLike.IdMedia.idMedia)
        //    );

        //    return _likes.Find(filter).FirstOrDefault();
        //}

        public Like Get(Like toGet) =>
            _likes.Find(like => (like.IdMedia.mediaType == toGet.IdMedia.mediaType && 
                                 like.IdMedia.idMedia == toGet.IdMedia.idMedia &&
                                 like.LikedBy == toGet.LikedBy)).FirstOrDefault();

        public bool Create(Like toCreate)
        {
            if (Get(toCreate) == null)
            {
                _likes.InsertOne(toCreate);
                return true;
            }
            else
            {
                Remove(toCreate.IdMedia.idMedia, toCreate.IdMedia.mediaType, toCreate.LikedBy);
                return false;
            }                
        }

        public void Remove(int id, int type, string userID) =>
          _likes.DeleteOne(
                  like => (like.IdMedia.mediaType == type &&
                           like.IdMedia.idMedia == id &&
                           like.LikedBy == userID));


    }
}

