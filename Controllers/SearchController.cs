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
        private static string URL = "https://api.themoviedb.org/3/search/multi?";

        [HttpGet]
        public string GetSearch(string query)
        {
            MediaSearch monObjet = JsonConvert.DeserializeObject<MediaSearch>(query);

            //using (var client = new HttpClient())
            //{
            //    //HTTP GET
            //    var responseTask = client.GetAsync(URL + "query=" + query + "&" + APIKey.apiKey);
            //    responseTask.Wait();

            //    var result = responseTask.Result;
            //    if (result.IsSuccessStatusCode)
            //    {
            //        var readTask = result.Content.ReadAsStringAsync();
            //        readTask.Wait();

            //        return readTask.Result;
            //    }
            //    else
            //    {
            //        ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            //        return "Nothing";
            //    }
            //}
            return monObjet.ToString();
        }
    }
}
