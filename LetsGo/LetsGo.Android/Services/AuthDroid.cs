using System;
using System.Threading.Tasks;
using Firebase;
using Firebase.Analytics;
using Firebase.Auth;
using LetsGo.Droid.Services;
using LetsGo.Helpers;
using LetsGo.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthDroid))]
namespace LetsGo.Droid.Services {
    public class AuthDroid : IAuth {
        public async Task<string> LoginWithEmailPassword(string email, string password) {
            try {
                var user = await FirebaseAuth.GetInstance(FirebaseApp.Instance).SignInWithEmailAndPasswordAsync(email, password);

                var token = await user.User.GetIdTokenAsync(false);
                return token.Token;
            }
            catch (Exception e)
            {
                AlertHelper.DisplayAlert("Erro", e.Message);
                return "";
            }
        }

        public async Task<bool> CreateUserWithEmailPassword(string email, string password) {
            try {
                var user = await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                
                return true;
            }
            catch (FirebaseAuthInvalidUserException e) {
                e.PrintStackTrace();
                return false;
            }
        }


    }
}