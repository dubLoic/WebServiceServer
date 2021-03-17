using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WebserviceServer.Entite;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {

        private static string URL = "https://api.themoviedb.org/3/genre/movie/list?";


        [HttpGet]
        public string GetGenreList()
        {

            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync(URL + APIKey.apiKey);
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

