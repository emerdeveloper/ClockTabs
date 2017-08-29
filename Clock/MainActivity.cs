using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;

namespace Clock
{
	[Activity(Label = "Clock", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Android.Support.V4.App.FragmentActivity //it adds properties to let your Activity host support Fragments
    {
        Android.Support.Design.Widget.TabLayout tabLayout;
		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
			SetContentView(Resource.Layout.Main);

            //FragmentLayout is a container that is intended to hold a single child
            //it is common to set the child from code
            tabLayout = FindViewById<Android.Support.Design.Widget.TabLayout>(Resource.Id.tabLayout);
            tabLayout.TabSelected += OnTabSelected;

            ShowFragment(new TimeFragment());
        }

        private void OnTabSelected(object sender, TabLayout.TabSelectedEventArgs e)
        {
            switch (e.Tab.Position) {
                case 0:
                    ShowFragment(new TimeFragment());
                    break;
                case 1:
                    ShowFragment(new StopwatchFragment());
                    break;
                case 2:
                    ShowFragment(new AboutFragment());
                    break;
            }
        }

        //Navigate to Fragment or beetwen tabs
        void ShowFragment(Android.Support.V4.App.Fragment fragment) {
            //Property of Android.Support.V4.App.FragmentActivity to work with Fragments
            //FragmentManager helps you dynamically add/remove fragments from your Activity's UI
            var transaction = base.SupportFragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.contentFrame,// Your FrameLayout where will show the Fragment or content
                fragment); //Your Fragment to show
            transaction.Commit();
        }
    }
}