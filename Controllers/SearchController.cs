using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebserviceServer.Entite;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private static string URL = "https://api.themoviedb.org/3";

        [HttpPost]
        public string Post(MediaSearch query)
        {
            using (var client = new HttpClient())
            {
                string extens = "";
                if (!string.IsNullOrEmpty(query.genre))
                    extens = "/discover/movie?with_genres=" + query.genre;
                else
                    extens = "/search/multi?query=" + query.text;

                //HTTP GET
                string url = URL + extens + "&" + APIKey.apiKey;
                var responseTask = client.GetAsync(url);
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
