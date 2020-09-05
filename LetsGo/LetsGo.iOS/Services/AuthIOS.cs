using System;
using System.Threading.Tasks;
using Firebase.Auth;
using LetsGo.iOS.Services;
using LetsGo.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthIOS))]
namespace LetsGo.iOS.Services {
    public class AuthIOS : IAuth {
        public async Task<string> LoginWithEmailPassword(string email, string password) {
            try {
                var user = await Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return await user.User.GetIdTokenAsync();
            }
            catch (Exception e) {
                return "";
            }

        }

        public async Task<bool> CreateUserWithEmailPassword(string email, string password)
        {
            try {
                var user = await Auth.DefaultInstance.CreateUserAsync(email, password);
                return true;
            }
            catch (Exception e) {
                return false;
            }
        }
    }
}