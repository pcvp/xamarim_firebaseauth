using System;
using System.Collections.Generic;
using System.Text;
using LetsGo.Helpers;
using LetsGo.Services;
using LetsGo.Views.Cadastro;
using LetsGo.Views.Inicio;
using Xamarin.Forms;

namespace LetsGo.ViewModels.Login {
    class LoginViewModel {
        public string Email { get; set; }
        public string Senha { get; set; }

        IAuth auth;

        public LoginViewModel() {
            auth = DependencyService.Get<IAuth>();
        }

        public Command IrParaOCadastro => new Command(async () => {
            await NavigationHelper.PushAsync(new CadastroPage());
        });

        public Command Logar => new Command(async () =>
        {
            string Token = await auth.LoginWithEmailPassword(Email, Senha);
            if (Token != "")
            {
                await NavigationHelper.PushAsync(new InicioPage());
            }
            else
            {
                AlertHelper.DisplayAlert("Atenção", "Email ou senha incorretos!", "Ok");
            }
        });
    }
}
