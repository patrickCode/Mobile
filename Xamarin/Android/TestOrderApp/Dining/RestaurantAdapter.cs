using System.Collections.Generic;
using Android.Views;
using Android.Support.V7.Widget;
using Dining.Model;
using System;

namespace Dining
{
    public class RestaurantAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> ItemClick;
        private List<Restaurant> _restaurants;
        public RestaurantAdapter(List<Restaurant> restaurants)
        {
            _restaurants = restaurants;
        }

        void OnItemClick(int position)
        {
            ItemClick?.Invoke(this, position);
        }

        public override int ItemCount
        {
            get
            {
                return _restaurants.Count;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Restaurant, parent, false);
            return new RestaurantViewHolder(view, new Action<int>(OnItemClick));
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var restaurant = _restaurants[position];
            var restautantHolder = (RestaurantViewHolder)holder;
            restautantHolder.NameView.Text= restaurant.Name;
            restautantHolder.Rating.Rating = restaurant.Rating;
        }
    }
}