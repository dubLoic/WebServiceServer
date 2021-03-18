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
                string extens = FormatUrl(query.mediaType, query?.genre, query?.text, out bool success);

                if(!success)
                    return JsonConvert.SerializeObject("Nothing");

                //HTTP GET
                string url = URL + extens + APIKey.apiKey;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return ConvertReceivedData(readTask.Result);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return "Nothing";
                }
            }
        }

        private string FormatUrl(int mediaType, string genre, string text, out bool success)
        {
            string type = mediaType == 1 ? "movie?" : "tv?";
            success = true;
            string extens = "";
            if (!string.IsNullOrEmpty(genre))
                extens = "/discover/"+ type + "with_genres=" + genre + "&";
            else if (!string.IsNullOrEmpty(text))
                extens = "/search/" + type + "query=" + text + "&";
            else
                success = false;
            return extens;
        }

        private string ConvertReceivedData(string jsonObject)
        {
            MediaResult res = JsonConvert.DeserializeObject<MediaResult>(jsonObject);
            MediaDTO[] medias = res.results;
            for (int i = 0; i < medias.Length; i++)
            {
                medias[i] = medias[i].Format();
            }
            return JsonConvert.SerializeObject(medias);
        }
    }
}
