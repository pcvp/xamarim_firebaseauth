using System.Threading.Tasks;
using Xamarin.Forms;

namespace LetsGo.Helpers {

    public static class AlertHelper {

        public static Task DisplayAlert(string title, string message, string cancel = "Ok") {
            var tcs = new TaskCompletionSource<bool>();

            Device.BeginInvokeOnMainThread(async () => {
                await Application.Current.MainPage.DisplayAlert(title, message, cancel);
                tcs.SetResult(false);
            });

            return tcs.Task;
        }

        public static Task<bool> DisplayAlert(string title, string message, string accept, string cancel) {
            var tcs = new TaskCompletionSource<bool>();

            Device.BeginInvokeOnMainThread(async () => {
                var retorno = await Application.Current.MainPage.DisplayAlert(title, message, accept, cancel);
                tcs.SetResult(retorno);
            });

            return tcs.Task;
        }
    }
}