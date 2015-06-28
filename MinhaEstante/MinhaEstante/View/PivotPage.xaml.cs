using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MinhaEstante.Model;

namespace MinhaEstante.View
{

    public sealed partial class PivotPage : Page
    {
        private ViewModel.LivroViewModel livroViewModel { get; set; }

        public PivotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var usuario = (Usuario) e.Parameter;
            if (usuario != null) NomeUsuarioTextBox.Text = "Bem vindo " + usuario.Nome.ToString() + "!";

            this.livroViewModel = new ViewModel.LivroViewModel();
            this.Livros.DataContext = this.livroViewModel;
        }

        private void AdicionarLivroButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.livroViewModel.EditLivro.Execute(new Model.Livro());
 
        }

        private void RemoverLivroButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
