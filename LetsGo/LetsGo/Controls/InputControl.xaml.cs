using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LetsGo.Controls {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputControl : StackLayout, INotifyPropertyChanged {

        public InputControl() {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
                Margin = new Thickness(5, 10);

            LabelCampoObrigatorio.IsVisible = false;
            BorderlessEntry.BindingContext = this;
            this.BorderlessEntry.SetBinding(Entry.TextProperty, nameof(Valor));
        }

        #region NomeDoCampo
        public static readonly BindableProperty NomeDoCampoProperty = BindableProperty.Create(
          propertyName: "NomeDoCampo",
          returnType: typeof(string),
          declaringType: typeof(InputControl),
          defaultBindingMode: BindingMode.Default,
          propertyChanged: ((bindable, oldvalue, newValue) => {
              var self = (InputControl)bindable;
              self.LabelNomeDoCampo.Text = newValue.ToString();
          })
        );


        public string NomeDoCampo {
            get { return (string)GetValue(NomeDoCampoProperty); }
            set { SetValue(NomeDoCampoProperty, value); }
        }
        #endregion

        #region Valor
        public static readonly BindableProperty ValorProperty = BindableProperty.Create(
           propertyName: nameof(Valor),
           returnType: typeof(string),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.TwoWay,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.BorderlessEntry.Text = newValue.ToString();
           })
       );


        public string Valor {
            get { return (string)GetValue(ValorProperty); }
            set { SetValue(ValorProperty, value); }
        }
        #endregion

        #region CorDaBorda
        public static readonly BindableProperty CorDaBordaProperty = BindableProperty.Create(
            propertyName: nameof(CorDaBorda),
            returnType: typeof(Color),
            declaringType: typeof(InputControl),
            defaultBindingMode: BindingMode.Default,
            propertyChanged: ((bindable, oldvalue, newValue) => {
                var self = (InputControl)bindable;
                self.FrameEntry.BorderColor = (Color)newValue;
            })
        );

        public Color CorDaBorda {
            get { return (Color)GetValue(CorDaBordaProperty); }
            set { SetValue(CorDaBordaProperty, value); }
        }
        #endregion

        #region MensagemDeErro
        public static readonly BindableProperty MensagemDeErroProperty = BindableProperty.Create(
           propertyName: nameof(MensagemDeErro),
           returnType: typeof(string),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.LabelErro.Text = newValue.ToString();
           })
       );


        public string MensagemDeErro {
            get { return (string)GetValue(MensagemDeErroProperty); }
            set { SetValue(MensagemDeErroProperty, value); }
        }
        #endregion

        #region ExibirErro
        public static readonly BindableProperty ExibirErroProperty = BindableProperty.Create(
           propertyName: nameof(ExibirErro),
           returnType: typeof(bool),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.LabelErro.IsVisible = (bool)newValue;
           })
       );


        public bool ExibirErro {
            get { return (bool)GetValue(ExibirErroProperty); }
            set { SetValue(ExibirErroProperty, value); }
        }
        #endregion

        #region Obrigatorio
        public static readonly BindableProperty ObrigatorioProperty = BindableProperty.Create(
           propertyName: nameof(Obrigatorio),
           returnType: typeof(bool),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.LabelCampoObrigatorio.IsVisible = (bool)newValue;
           })
       );


        public bool Obrigatorio {
            get { return (bool)GetValue(ObrigatorioProperty); }
            set { SetValue(ObrigatorioProperty, value); }
        }
        #endregion

        #region IsPassword
        public static readonly BindableProperty IsPasswordProperty = BindableProperty.Create(
           propertyName: nameof(IsPassword),
           returnType: typeof(bool),
           declaringType: typeof(InputControl),
           defaultBindingMode: BindingMode.Default,
           propertyChanged: ((bindable, oldvalue, newValue) => {
               var self = (InputControl)bindable;
               self.BorderlessEntry.IsPassword = (bool)newValue;
           })
       );


        public bool IsPassword {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }
        #endregion
    }
}