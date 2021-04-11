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
    public class LikeService
    {
        private readonly IMongoCollection<Like> _likes;
        public LikeService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _likes = database.GetCollection<Like>(settings.UserCollectionName);

        }

        public List<Like> Get()
        {
            List<Like> likes;
            likes = _likes.Find(like => true).ToList();
            return likes;
        }


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

        public Like Create(Like toCreate)
        {
            _likes.InsertOne(toCreate);
            return toCreate;
        }

        public void Update(Like toUpdate)
        {
            Like like = Get(toUpdate);
            if (like != null)
                Remove(like);
            else
                Create(like);
        }

        public void Remove(Like toRemove) =>
            _likes.DeleteOne(like => (like == toRemove));
        //  _likes.DeleteOne(
        //          like => (like.IdMedia.mediaType == toRemove.IdMedia.mediaType && 
        //                   like.IdMedia.idMedia == toRemove.IdMedia.idMedia &&
        //                   like.LikedBy == toRemove.LikedBy &&


    }
}

