using Android.App;
using Android.Widget;
using Android.OS;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Android.Content;
using Chronos.Droid.Authorization;
using System.Threading.Tasks;

namespace Chronos.Droid
{
    [Activity(Label = "Chronos", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private AuthContext _authContext;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            var clientId = "4ebc2944-2b59-4373-a120-fbf74aabd5d1";
            var resourceId = "https://graph.windows.net";
            var redirectUri = "http://ps-xama-native-redirect";
            var authority = "https://login.windows.net/72f988bf-86f1-41af-91ab-2d7cd011db47";

            _authContext = new AuthContext(clientId, resourceId, redirectUri, authority);

            //if (_authContext.IsTokenCached())
            //{
            //    var intent = new Intent(this, typeof(AssignmentActivity));
            //    StartActivity(intent);
            //}
            //else
            //{
            //    _authContext.SignIn(this);
            //}

            //Force Sign-In
            _authContext.SignIn(this);
        }

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);


            var dialog = new AlertDialog.Builder(this);
            //var user = await _authContext.GetUser(this);
            dialog.SetMessage($"Welcome to Chronos");
            dialog.SetNeutralButton("Continue", (sender, args) =>
            {
                var intent = new Intent(this, typeof(AssignmentActivity));
                StartActivity(intent);
            });
            dialog.Show();
            //Task.Run(async () =>
            //{
            //    var dialog = new AlertDialog.Builder(this);
            //    var user = await _authContext.GetUser(this);
            //    dialog.SetMessage($"Hello {user.Name}! Welcome to Chronos");
            //    dialog.SetNeutralButton("Continue", (sender, args) =>
            //    {
            //        var intent = new Intent(this, typeof(AssignmentActivity));
            //        StartActivity(intent);
            //    });
            //});
        }
    }
}

