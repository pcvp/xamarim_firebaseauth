using LetsGo.Helpers;
using LetsGo.Services;
using Xamarin.Forms;

namespace LetsGo.ViewModels.Cadastro {
    public class CadastroViewModel {


        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        IAuth auth;

        public CadastroViewModel() {
            auth = DependencyService.Get<IAuth>();
        }

        public Command IrParaOLogin => new Command(async () => {
            await NavigationHelper.PushAsync(new LoginPage());
        });

        public Command CadastrarCommand => new Command(async () => {
            bool sucesso = await auth.CreateUserWithEmailPassword(Email, Senha);
            if (sucesso) {
                await NavigationHelper.PushAsync(new LoginPage());
            }
            else {
                AlertHelper.DisplayAlert("Atenção", "Erro ao tentar salvar suas informações!", "Ok");
            }
        });
    }
}
