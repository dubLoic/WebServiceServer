using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TvShow : ControllerBase
    {
       private static string URL = "https://api.themoviedb.org/3/tv/";

        [HttpGet]
        public string GetMovie(int tvId)
        {
            using (var client = new HttpClient())
            {
                //HTTP GET
                var responseTask = client.GetAsync(URL + tvId + "?" + APIKey.apiKey);
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
