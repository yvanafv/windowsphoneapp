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
        private ViewModel.LivroViewModel LivroViewModel { get; set; }

        public PivotPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var usuario = (Usuario) e.Parameter;
            if (usuario != null) NomeUsuarioTextBox.Text = "Bem vindo " + usuario.Nome.ToString() + "!";

            this.LivroViewModel = new ViewModel.LivroViewModel();
            this.Livros.DataContext = this.LivroViewModel;
        }

        private void AdicionarLivroButton_OnClick(object sender, RoutedEventArgs e)
        {
            this.LivroViewModel.EditLivro.Execute(new Model.Livro());
 
        }

        private void RemoverLivroButton_OnClick(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuFlyoutEmprestar_Click(object sender, RoutedEventArgs e)
        {
            Model.Emprestimo novoEmprestimo = new Emprestimo();
            novoEmprestimo.Livro = (Model.Livro)((MenuFlyoutItem)e.OriginalSource).CommandParameter;

            ViewModel.EmprestimoViewModel emprestimoViewModel = new ViewModel.EmprestimoViewModel();
            emprestimoViewModel.SelectedEmprestimo = novoEmprestimo;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoEmprestimoPage), emprestimoViewModel);
        }
    }
}
