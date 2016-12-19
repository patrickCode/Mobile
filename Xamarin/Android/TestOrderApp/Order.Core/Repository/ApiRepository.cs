using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Core.Models;
using System.Net.Http;
using Newtonsoft.Json;

namespace Order.Core.Repository
{
    public class ApiRepository : IRepository
    {
        public IEnumerable<Book> GetAllBooks()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://phxmobileapi.azurewebsites.net/api/books").Result;
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Book>>(jsonStr);
            }
        }

        public IEnumerable<Book> GetByGenre(string genreName)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://phxmobileapi.azurewebsites.net/api/genre/" + genreName + "/books").Result;
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Book>>(jsonStr);
            }
        }

        public Book GetById(int Id)
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://phxmobileapi.azurewebsites.net/api/books/" + Id).Result;
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Book>(jsonStr);
            }
        }

        public IEnumerable<Book> GetFavouriteProducts()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("http://phxmobileapi.azurewebsites.net/api/books?favourite=true").Result;
                var jsonStr = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Book>>(jsonStr);
            }
        }

        public Subject GetProductGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Subject> GetProductGroups()
        {
            throw new NotImplementedException();
        }
    }
}
