using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MinhaEstante.Model;

namespace MinhaEstante.View
{

    public sealed partial class MainPage : Page
    {
        private ViewModel.UsuarioViewModel UsuarioViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //this.navigationHelper.OnNavigatedTo(e);

            if (!string.IsNullOrEmpty(e.Parameter.ToString()))
                this.DataContext = (ViewModel.UsuarioViewModel)e.Parameter;
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
            this.UsuarioViewModel = new ViewModel.UsuarioViewModel();
            this.UsuarioViewModel.LoginUsuario.Execute(new Usuario(UsuarioTextBox.Text, SenhaPasswordBox.Password));
        }

        public void CadastrarButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CadastroPage));
        }
    }
}
