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
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Threading.Tasks;

namespace TestOrderApp
{
    [Activity(Label = "My Book Store", MainLauncher = true, Icon = "@drawable/bookIcon")]
    public class MenuActivity : Activity
    {
        private Button _signInButton;
        private Button _storeButton;
        private Button _mapButton;
        private Button _aboutButton;
        private Button _picButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);


            FindViews();
            HandleEvents();
        }
        private void FindViews()
        {
            _signInButton = FindViewById<Button>(Resource.Id.loginButton);
            _storeButton = FindViewById<Button>(Resource.Id.goToStoreMainMenuButton);
            _mapButton = FindViewById<Button>(Resource.Id.seeMapMainMenuButton);
            _aboutButton = FindViewById<Button>(Resource.Id.aboutMainMenuButton);
            _picButton = FindViewById<Button>(Resource.Id.takePicMainMenuButton);
        }

        private void HandleEvents()
        {
            _storeButton.Click += _storeButton_Click;
            _aboutButton.Click += _aboutButton_Click;
            _picButton.Click += _picButton_Click;
            _mapButton.Click += _mapButton_Click;
            _signInButton.Click += async (s, a) =>
            {
                await _signInButton_Click(s, a);
            };
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }

        private async Task _signInButton_Click(object sender, EventArgs e)
        {
            try
            {
                AuthenticationResult authResult;
                var authContext = new AuthenticationContext("https://login.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47");
                if (authContext.TokenCache.ReadItems().Count() > 0)
                {
                    authContext = new AuthenticationContext(authContext.TokenCache.ReadItems().First().Authority);
                    authResult = await authContext.AcquireTokenSilentAsync("https://graph.windows.net", "4ebc2944-2b59-4373-a120-fbf74aabd5d1");
                }
                    

                authResult = await authContext.AcquireTokenAsync("https://graph.windows.net", "4ebc2944-2b59-4373-a120-fbf74aabd5d1", new Uri("http://ps-xama-native-redirect"), new PlatformParameters(this));
                //var authResult = await authContext.AcquireTokenAsync("http://graph.windows.net", "", new UserAssertion(""));
            }
            catch (Exception error)
            {
                throw error;
            }

        }


        

        private void _mapButton_Click(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(OpenMapActivity));
            var intent = new Intent(this, typeof(MapViewActivity));
            StartActivity(intent);
        }

        private void _picButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(TakePicActivity));
            StartActivity(intent);
        }

        private void _aboutButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(AboutUsActivity));
            StartActivity(intent);
        }

        private void _storeButton_Click(object sender, EventArgs e)
        {
            //var intent = new Intent(this, typeof(ProductMenuActivity));
            var intent = new Intent(this, typeof(ProductTabActivity));
            StartActivity(intent);
        }
    }
}