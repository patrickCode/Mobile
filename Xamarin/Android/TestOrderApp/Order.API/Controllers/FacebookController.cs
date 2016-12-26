using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{
    public class FacebookController : Controller
    {
        private static List<object> _fbObjects = new List<object>();

        [HttpGet]
        [Route("api/fb/callback")]
        public string PagaCallbackVerify()
        {
            var sub = Request.Query["hub.mode"];
            var challenge = Request.Query["hub.challenge"];
            var verification = Request.Query["hub.verify_token"];
            return challenge;
        }

        [HttpPost]
        [Route("api/fb/callback")]
        public string PageCallback([FromBody]object data)
        {
            var sub = Request.Query["hub.mode"];
            var challenge = Request.Query["hub.challenge"];
            var verification = Request.Query["hub.verify_token"];
            _fbObjects.Add(data);
            return challenge;
        }

        [HttpGet]
        [Route("api/fb")]
        public List<object> GetCallbacks()
        {
            return _fbObjects;
        }
    }
}
