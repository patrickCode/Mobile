using Java.Lang;

namespace ClockTab
{
    public class ClockAdapter : Android.Support.V4.App.FragmentPagerAdapter
    {
        private Android.Support.V4.App.Fragment[] fragments;
        private ICharSequence[] titles;

        public ClockAdapter(Android.Support.V4.App.FragmentManager fragmentManager,
             Android.Support.V4.App.Fragment[] fragments,
             ICharSequence[] titles)
            : base(fragmentManager)
        {
            this.fragments = fragments;
            this.titles = titles;
        }
        public override int Count
        {
            get
            {
                return fragments.Length;
            }
        }
        

        public override Android.Support.V4.App.Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return titles[position];
        }
    }
}