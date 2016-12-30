using System;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;

namespace Dining
{
    public class RestaurantViewHolder: RecyclerView.ViewHolder
    {
        public TextView NameView { get; set; }
        public RatingBar Rating { get; set; }
        public RestaurantViewHolder(View itemView, Action<int> listener): base(itemView)
        {
            NameView = itemView.FindViewById<TextView>(Resource.Id.restaurantName);
            Rating = itemView.FindViewById<RatingBar>(Resource.Id.ratingBar);
            NameView.Click += (s, e) =>
            {
                listener(AdapterPosition);
            };
        }
    }
}