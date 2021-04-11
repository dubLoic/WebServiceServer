using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebserviceServer.Entities;

namespace WebserviceServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private static string URL = "https://api.themoviedb.org/3";

        [HttpGet("{mediaType}")]
        public string Get(int mediaType)
        {
            using (var client = new HttpClient())
            {
                string extens = FormatUrl(mediaType, APIKey.apiKey);

                //HTTP GET
                string url = URL + extens;
                var responseTask = client.GetAsync(url);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    readTask.Wait();

                    return ConvertReceivedData(readTask.Result, mediaType);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                    return "Nothing";
                }
            }
        }

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

                    return ConvertReceivedData(readTask.Result, query.mediaType);
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

        private string FormatUrl(int mediaType, string key)
        {
            string type = mediaType == 1 ? "movie?" : "tv?";

            return "/discover/" + type + key + "&language=en-US&sort_by=popularity.desc&include_adult=false&include_video=false&page=1";
        }

        private string ConvertReceivedData(string jsonObject, int mediaType)
        {
            MediaResult res = JsonConvert.DeserializeObject<MediaResult>(jsonObject);
            MediaDTO[] medias = res.results;
            for (int i = 0; i < medias.Length; i++)
            {
                medias[i] = medias[i].Format(mediaType);
            }
            return JsonConvert.SerializeObject(medias);
        }
    }
}
