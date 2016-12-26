using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Formatting;

namespace Order.API.Controllers
{
    public class TaskController: Controller
    {
        private static Dictionary<Guid, string> _subcribers = new Dictionary<Guid, string>();

        [HttpPost]
        [Route("api/tasks")]
        public void Process([FromBody] string callBackUri)
        {
            var tracker = Guid.NewGuid();
            _subcribers.Add(tracker, callBackUri);
            Task.Run(() =>
            {
                Process(tracker);
            });
        }

        [HttpPost]
        [Route("api/tasks/unsubscribe")]
        public void Unsubscribe([FromBody] string callBackUri)
        {
            var tracker = Guid.NewGuid();
            var subscriber = _subcribers.FirstOrDefault(sub => sub.Value.Equals(callBackUri));
            _subcribers.Remove(subscriber.Key);
        }

        private void Process(Guid guid)
        {
            Task.Delay(2000).Wait();
            using (HttpClient client = new HttpClient())
            {
                var res = client.PostAsync(_subcribers[guid], "{'data':'Done'}", new JsonMediaTypeFormatter(), "application/json").Result;
            }
        }


        [HttpGet]
        [Route("api/tasks")]
        public Dictionary<Guid, string> GetAllSubscribers()
        {
            return _subcribers;
        }
    }
}