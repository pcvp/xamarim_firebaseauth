using LetsGo.Helpers;
using System.ComponentModel;
using Xamarin.Forms;

namespace LetsGo.ViewModels.Base {
    public class BaseViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public int IdUsuario => Helpers.UsuarioHelper.GetIdLogado();

        public bool MostrarLoading { get; set; }

        

       

    }
}
