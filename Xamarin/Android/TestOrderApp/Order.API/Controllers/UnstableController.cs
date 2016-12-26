using Microsoft.AspNetCore.Mvc;
using Order.API.Models;
using Order.API.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order.API.Controllers
{   
    public class UnstableController: Controller
    {
        private static Dictionary<int, int> _taskCount = new Dictionary<int, int>();
        private readonly IBookService _bookService;

        public UnstableController()
        {
            _bookService = new InMemoryBookService();
        }

        [Route("api/books/{id}/vUnstable")]
        public Book GetItem(int id)
        {
            if (!_taskCount.ContainsKey(id))
                _taskCount.Add(id, 1);

            if (_taskCount[id] <= 3)
            {
                _taskCount[id] = _taskCount[id] + 1;
                throw new Exception("Some Error Ocurred");
            }   

            _taskCount.Remove(id);
            return _bookService.GetById(id);
        }
    }
}