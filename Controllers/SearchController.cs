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
                string extens = "/search/multi?";
                if (!string.IsNullOrEmpty(query.genre))
                    extens = "/discover/movie?with_genres=" + query.genre + "&";
                else if (!string.IsNullOrEmpty(query.text))
                    extens = "/search/multi?query=" + query.text + "&";
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return JsonConvert.SerializeObject("Nothing");
                }

                //HTTP GET
                string url = URL + extens + APIKey.apiKey;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    // We got a result
                    MediaResult jsonRes = JsonConvert.DeserializeObject<MediaResult>(readTask.Result);
                    MediaDTO[] medias = jsonRes.results;

                    // TODO : keep the good media_type (tv show / movie)


                    return JsonConvert.SerializeObject(medias);
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
