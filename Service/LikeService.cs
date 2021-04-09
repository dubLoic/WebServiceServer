using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entite;

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

        public Like Get1(Like tempLike) =>
            _likes.Find(like => (like.IdMedia.mediaType == tempLike.IdMedia.mediaType && like.IdMedia.idMedia == tempLike.IdMedia.idMedia)).FirstOrDefault();

        public Like Get(Like tempLike)
        {
            var filter = Builders<Like>.Filter.And(
                Builders<Like>.Filter.Eq("IdMedia.mediaType", tempLike.IdMedia.mediaType),
                Builders<Like>.Filter.Eq("IdMedia.idMedia", tempLike.IdMedia.idMedia)
            );

            return _likes.Find(filter).FirstOrDefault();
        }

        public Like Create(Like like)
        {
            _likes.InsertOne(like);
            return like;
        }

        public void Update(Like likeIn)
        {

            _likes.ReplaceOne(
                filter: new BsonDocument("IdMedia", likeIn.IdMedia.idMedia),
                options: new ReplaceOptions { IsUpsert = true },
                replacement: likeIn);
        }

        public void Remove(Like likeIn) =>
            _likes.DeleteOne(like => (like.IdMedia.mediaType == likeIn.IdMedia.mediaType && like.IdMedia.idMedia == likeIn.IdMedia.idMedia));


        //_likes.DeleteOne(like => like.Id == likeIn.Id);


    }
}

