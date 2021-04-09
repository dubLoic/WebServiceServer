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
    public class LikesController : ControllerBase
    {
        private readonly LikeService _likeService;

        public LikesController(LikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpGet]
        public List<Like> Get() =>
            _likeService.Get();

        [HttpGet("{id:length(24)}", Name = "GetLike")]
        public Like Get(Like likeIn)
        {
            var like = _likeService.Get(likeIn);

            if (like == null)
            {
                return null;
            }

            return like;
        }

        [HttpPost]
        public Like CreateOrUpdate(Like like)
        {
            //Delete(like);

            _likeService.Create(like);

            var getLike = Get(like);
            return getLike;
        }


        [HttpDelete("{id:length(24)}")]
        public bool Delete(Like like)
        {
            var likeExist = Get(like);
            if (likeExist == null)
            {
                return false;
            }

            _likeService.Remove(like);

            var getLike = Get(like);
            if (getLike == null)
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
