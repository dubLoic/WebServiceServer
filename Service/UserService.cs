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

        public User Get(User tempUser) =>
            _users.Find(user => (user.userName == tempUser.userName && user.userName == tempUser.userName)).FirstOrDefault();

        public User CreateUser(User newUser)
        {
            User user = Get(newUser);
            if(user == null)
            {
                user = newUser;
                _users.InsertOne(user);
            }
            return user;
        }

        public void Remove(User userIn) =>
            _users.DeleteOne(user => (user.userName == userIn.userName));
    }
}

