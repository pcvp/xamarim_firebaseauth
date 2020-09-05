using Xamarin.Forms;

namespace LetsGo.Controls {

    public class BorderlessEntryControl : Entry {

        public BorderlessEntryControl() {
            if (Device.RuntimePlatform == Device.iOS)
                this.Margin = new Thickness(5, 10);

            FontSize = 15;
            TextColor = (Color)App.Current.Resources["CorTexto"];
        }
    }
}