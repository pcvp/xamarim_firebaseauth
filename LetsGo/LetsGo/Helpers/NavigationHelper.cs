using System.Threading.Tasks;
using Xamarin.Forms;

namespace LetsGo.Helpers {

    public static class NavigationHelper {

        #region Paginas

        public static Task PushAsync(Page page) {
            var tcs = new TaskCompletionSource<Page>();

            Device.BeginInvokeOnMainThread(async () => {
                try
                {
                    Application.Current.MainPage = new NavigationPage(page);
                    tcs.SetResult(null);
                }
                catch (System.Exception e) {
                  
                }
            });

            return tcs.Task;
        }

        #endregion Paginas
        
    }
}