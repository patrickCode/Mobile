using GroceryList.Model;
using System.Collections.Generic;

namespace GroceryList.Repository
{
    public class ItemRepository
    {
        public static List<Item> Items = new List<Item>()
        {
            new Item("Milk", 1),
            new Item("Bananas", 6)
        };
        
        public List<Item> Get()
        {
            return Items;
        }

        public void Add(string itemName, long count)
        {
            Items.Add(new Item(itemName, count));
        }
    }
}