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
    public class LikeController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikeController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public List<Like> Get() =>
            _likeService.Get();

        [HttpGet("{id}/{type}")]
        public ResponseMessage GetLikesForSelectedMedia(string id, string type)
        {
            ResponseMessage rm = new ResponseMessage()
            {
                count = _likeService.GetLikesForSelectedMedia(Int32.Parse(id), Int32.Parse(type)).Count()
            };
            return rm;
        }

        [HttpPost]
        public ResponseMessage Create(Like like)
        {
            bool added = _likeService.Create(like);

            ResponseMessage rm = new ResponseMessage()
            {
                count = _likeService.Get().Count(),
            msg = added ? "Added to your Favorites" : "Removed from your Favorites"
            };

            return rm;
        }
    }
}
