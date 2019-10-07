using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SampleApp.API.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            var client = new RestClient("https://cloudassets.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"NNPnIPi0bDxleYZoQDyOdmzTOuhwp4gL\",\"client_secret\":\"zC7ZTy0DcgZUn2V_xW2t6-LfaYlCQIa6wiG034lJ_j2_7X1M8qQBCeGgpw9pNk6N\",\"audience\":\"https://cloudassets/api\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic jsonObject = JObject.Parse(response.Content);
            string accessToken = jsonObject.access_token.ToString();
            return base.Content(accessToken, "text/html");
        }
    }
}
