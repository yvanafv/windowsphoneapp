using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MinhaEstante.Model;

namespace MinhaEstante.View
{

    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }

        private bool VerificarLogin()
        {
            return !string.IsNullOrEmpty(UsuarioTextBox.Text)
                   && !string.IsNullOrEmpty(SenhaPasswordBox.Password)
                   && UsuarioTextBox.Text == "admin"
                   && SenhaPasswordBox.Password == "admin";
        }


        public void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (VerificarLogin())
            {
                Frame.Navigate(typeof (PivotPage), new Usuario("admin", UsuarioTextBox.Text, SenhaPasswordBox.Password));
            }
        }

        public void CadastrarButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CadastroPage));
        }
    }
}
