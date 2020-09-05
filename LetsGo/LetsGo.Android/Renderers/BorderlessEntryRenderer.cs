using Android.Content;
using Android.Graphics.Drawables;
using LetsGo.Controls;
using TrinksPro.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntryControl), typeof(BorderlessEntryRenderer))]

namespace TrinksPro.Droid.Renderers {

    public class BorderlessEntryRenderer : EntryRenderer {

        public BorderlessEntryRenderer(Context context)
            : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
            }
        }
    }
}