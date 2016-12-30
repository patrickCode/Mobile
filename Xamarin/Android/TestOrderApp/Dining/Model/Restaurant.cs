using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Dining.Model
{
    public class Restaurant
    {
        public Restaurant(string name, float rating)
        {
            Name = name;
            Rating = rating;
        }

        public string Name { get; set; }
        public float Rating { get; set; }
    }
}