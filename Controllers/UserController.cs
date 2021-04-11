using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entities;
using WebserviceServer.Entities.MongoObjects;
using WebserviceServer.Service;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetUser() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public User GetUser(User userIn)
        {
            var user = _userService.Get(userIn);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        [HttpPost]
        public User CreateOrSignin(User user)
        {
            return _userService.CreateUser(user);
        }
    }
}
