using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Order.API.Controllers
{
    [Route("api/logs")]
    public class LoggerController : Controller
    {
        private static List<Log> _logs = new List<Log>();

        [HttpPost]
        public void LogMessage([FromBody]Log log)
        {   
            _logs.Add(log);
        }

        [HttpGet]
        public List<Log> GetAllLogs()
        {
            return _logs;
        }

        [HttpGet]
        [Route("{correlationId}")]
        public IEnumerable<Log> GetLog([FromRoute]string correlationId)
        {
            return _logs.Where(log => log.CorrelationId.Equals(correlationId));
        }

        [HttpDelete]
        public void Reset()
        {
            _logs = new List<Log>();
        }
    }

    public class Log
    {
        public string CorrelationId { get; set; }
        public string Message { get; set; }
    }
}