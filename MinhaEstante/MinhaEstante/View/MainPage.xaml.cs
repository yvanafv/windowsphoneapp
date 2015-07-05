using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MinhaEstante.Model;
using System;
using Windows.UI.Popups;
using MinhaEstante.Common;

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

            if (e.Parameter != null && !string.IsNullOrEmpty(e.Parameter.ToString()))
                this.DataContext = (ViewModel.UsuarioViewModel)e.Parameter;
        }

        public void LoginButton_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                this.UsuarioViewModel = new ViewModel.UsuarioViewModel();
                this.UsuarioViewModel.LoginUsuario.Execute(new Usuario(UsuarioTextBox.Text, SenhaPasswordBox.Password));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void CadastrarButton_OnClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CadastroPage));
        }
    }
}
