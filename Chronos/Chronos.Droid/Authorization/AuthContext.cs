using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

using Android.App;
using Android.Content;
using Chronos.Core.Model;

namespace Chronos.Droid.Authorization
{
    public class AuthContext
    {
        private string _clientId;
        private string _resourceId;
        private string _redirectUrl;
        private string _authority;
        private static User user;


        public AuthContext(string clientId, string resourceId, string redirectUrl, string authority)
        {
            _clientId = clientId;
            _resourceId = resourceId;
            _redirectUrl = redirectUrl;
            _authority = authority;
        }

        public async Task<string> GetToken(Activity currentActivity)
        {
            AuthenticationResult authResult;
            var authContext = new AuthenticationContext(_authority);
            if (authContext.TokenCache.ReadItems().Count() > 0)
            {
                authResult = await authContext.AcquireTokenSilentAsync(_resourceId, _clientId);
                return authResult.AccessToken;
            }
            else
            {
                var intent = new Intent(currentActivity, typeof(MainActivity));
                currentActivity.StartActivity(intent);
            }
            return null;
        }

        public bool IsTokenCached()
        {
            var authContext = new AuthenticationContext(_authority);
            return (authContext.TokenCache.ReadItems().Count() > 0);
        }

        public async Task SignIn(Activity currentContext)
        {
            var authContext = new AuthenticationContext(_authority);
            //Force Sign-in
            authContext.TokenCache.Clear();
            var authResult = await authContext.AcquireTokenAsync(_resourceId, _clientId, new Uri(_redirectUrl), new PlatformParameters(currentContext));
            user = new User()
            {
                Name = authResult.UserInfo.GivenName,
                EmailAddress = authResult.UserInfo.DisplayableId,
                UPN = authResult.UserInfo.DisplayableId
            };
        }

        //public async Task<User> GetUser(Activity currentContext)
        //{
        //    if (user == null)
        //    {
        //        var authContext = new AuthenticationContext(_authority);
        //        AuthenticationResult authResult;
        //        try
        //        {
        //            authResult = await authContext.AcquireTokenSilentAsync(_resourceId, _clientId);
        //            user = new User()
        //            {
        //                Name = authResult.UserInfo.GivenName,
        //                EmailAddress = authResult.UserInfo.DisplayableId,
        //                UPN = authResult.UserInfo.DisplayableId
        //            };
        //        }
        //        catch (Exception ex)
        //        {

        //        }

        //    }
        //    return user;
        //}
    }
}