using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsGo.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RoundedButtonControl : Frame {
        public RoundedButtonControl() {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e) {
            Execute(Command, CommandParameter);
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(RoundedButtonControl), null);

        public ICommand Command {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(RoundedButtonControl), null);

        public object CommandParameter {
            get => (object)GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty TextoProperty =
            BindableProperty.Create(nameof(Texto), typeof(string), typeof(RoundedButtonControl), null,
                propertyChanged: (bindable, value, newValue) => {
                    var self = (RoundedButtonControl)bindable;
                    self.LabelTexto.Text = newValue.ToString();
                });

        public string Texto {
            get => (string)GetValue(TextoProperty);
            set => SetValue(TextoProperty, value);
        }

        public static readonly BindableProperty TipoProperty =
            BindableProperty.Create(nameof(Tipo), typeof(string), typeof(RoundedButtonControl), null,
                propertyChanged: (bindable, value, newValue) => {
                    var self = (RoundedButtonControl)bindable;
                    var tipo = newValue.ToString();

                    if ("secundario".Equals(tipo.ToLower())) {
                        self.FrameBotao.Style = (Style)Application.Current.Resources["FrameBotaoSecundario"];
                        self.LabelTexto.Style = (Style)Application.Current.Resources["BotaoSecundario"];
                    }
                    else {
                        self.FrameBotao.Style = (Style)Application.Current.Resources["FrameBotaoPrimario"];
                        self.LabelTexto.Style = (Style)Application.Current.Resources["BotaoPrimario"];

                    }

                });

        public string Tipo {
            get => (string)GetValue(TipoProperty);
            set => SetValue(TipoProperty, value);
        }


        private static void Execute(ICommand command, object parameter) {
            if (command == null) return;
            if (command.CanExecute(parameter)) {
                command.Execute(parameter);
            }
        }
    }
}