using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebserviceServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchGenreController : ControllerBase
    {
        private static string URL = "https://api.themoviedb.org/3/discover/movie?";

        [HttpGet]
        public string GetSearchByGenre(int genreId)
        {
            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync(URL + "with_genres=" + genreId + "&" + APIKey.apiKey);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return readTask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return "Nothing";
                }
            }
        }
    }
}
