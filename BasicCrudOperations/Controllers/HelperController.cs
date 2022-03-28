using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasicCrudOperations.Controllers
{
    public class HelperController : Controller
    {
        private readonly IConfiguration _config;

        public HelperController(IConfiguration config)
        {
            _config = config;
        }
        private string BaseUrl
        {
            get
            {
                return _config["BaseUrl"];
            }
        }

        protected async Task<string> SendGetWebReqest(string url)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BaseUrl + url))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    return apiResponse;
                }
            }
        }
    }
}
