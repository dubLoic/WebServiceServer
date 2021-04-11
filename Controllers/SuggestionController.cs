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
    public class SuggestionController : ControllerBase
    {
        private readonly SuggestionService _suggestionService;
        private readonly UserService _userService;

        public SuggestionController(SuggestionService suggestionService, UserService userService)
        {
            _suggestionService = suggestionService;
            _userService = userService;
        }

        [HttpGet]
        public List<Suggestion> Get() =>
            _suggestionService.Get();

        [HttpGet("suggs")]
        public ResponseMessage GetSuggestionsForSelectedMedia([FromQuery] string id, [FromQuery] string type, [FromQuery] string suggestedTo)
        {
            ResponseMessage rm = new ResponseMessage
            {
                count = _suggestionService.GetSuggestionsForSelectedMedia(Int32.Parse(id), Int32.Parse(type), suggestedTo).Count()
            };
            return rm;
        }

        [HttpPost]
        public ResponseMessage Create(Suggestion suggestion)
        {
            User user = _userService.Get(suggestion.SuggestedTo);
            bool added = _suggestionService.Create(suggestion);
            ResponseMessage rm = new ResponseMessage
            {
                msg = added ? "Suggested this media to " + user.Username : "Removed suggestion to " + user.Username
            };
            return rm;
        }
    }
}
