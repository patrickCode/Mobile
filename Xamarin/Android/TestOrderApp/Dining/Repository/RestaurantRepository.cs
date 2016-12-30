using Dining.Model;
using System.Collections.Generic;

namespace Dining.Repository
{
    public class RestaurantRepository
    {
        private static List<Restaurant> restaurants;
        public RestaurantRepository()
        {
            restaurants = new List<Restaurant>();
            restaurants.Add(new Restaurant("Joe's Coffee Shop", 3.5F));
            restaurants.Add(new Restaurant("Bakehouse Cakes", 2.0F));
            restaurants.Add(new Restaurant("Silver Spoon Diner", 2.5F));
            restaurants.Add(new Restaurant("Pasta Connection", 4.0F));
            restaurants.Add(new Restaurant("Main Grill", 1.0F));
            restaurants.Add(new Restaurant("Pizza Central", 2.0F));
            restaurants.Add(new Restaurant("Taverna on Main", 5.0F));
            restaurants.Add(new Restaurant("Cow & Pig", 3.0F));
        }
        public List<Restaurant> GetRestaurants()
        {
            return restaurants;
        }
    }
}