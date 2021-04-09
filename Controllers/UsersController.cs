using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebserviceServer.Entite;
using WebserviceServer.Service;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public List<User> GetUser() =>
            _userService.Get();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public User GetUser(User userIn)
        {
            var user = _userService.GetUser(userIn);

            if (user == null)
            {
                return null;
            }

            return user;
        }

        [HttpPost]
        public User CreateOrUpdate(User user)
        {
            //Delete(user);

            _userService.CreateUser(user);

            var getUser = GetUser(user);
            return getUser;
        }


        [HttpDelete("{id:length(24)}")]
        public bool Delete(User user)
        {
            var userExist = GetUser(user);
            if (userExist == null)
            {
                return false;
            }

            _userService.Remove(user);

            var getUser = GetUser(user);
            if (getUser == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
