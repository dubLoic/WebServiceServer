using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entite;

namespace WebserviceServer.Service
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        public UserService(IMovieDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>(settings.UserCollectionName);

        }

        public List<User> Get()
        {
            List<User> users;
            users = _users.Find(user => true).ToList();
            return users;
        }

        public User GetUser(User tempUser) =>
            _users.Find(user => (user.userName == tempUser.userName && user.userName == tempUser.userName)).FirstOrDefault();

        //  Exemple Get pour un filtre multiple
        //public User Get(User tempUser)
        //{
        //    var filter = Builders<User>.Filter.And(
        //        Builders<User>.Filter.Eq("IdMedia.mediaType", tempUser.IdMedia.mediaType),
        //        Builders<User>.Filter.Eq("IdMedia.idMedia", tempUser.IdMedia.idMedia)
        //    );

        //    return _users.Find(filter).FirstOrDefault();
        //}

        public User CreateUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        //public void UpdateLike(User userIn)
        //{

        //    _users.ReplaceOne(
        //        filter: new BsonDocument("IdMedia", userIn.IdMedia.idMedia),
        //        options: new ReplaceOptions { IsUpsert = true },
        //        replacement: userIn);
        //}

        public void Remove(User userIn) =>
            _users.DeleteOne(user => (user.userName == userIn.userName));


            //_users.DeleteOne(user => user.Id == userIn.Id);


    }
}

