using MinhaEstante.Common;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MinhaEstante.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NovoEmprestimoPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();
        private ViewModel.EmprestimoViewModel EmprestimoViewModel { get; set; }
        public NovoEmprestimoPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
        }

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

            ViewModel.EmprestimoViewModel emprestimo = new ViewModel.EmprestimoViewModel();
            emprestimo = (ViewModel.EmprestimoViewModel)e.Parameter;
            ViewModel.UsuarioViewModel usuario = new ViewModel.UsuarioViewModel();
            emprestimo.SelectedEmprestimo.Usuario = usuario.ListaDeUsuarios.FirstOrDefault();

            if (emprestimo.SelectedEmprestimo.ID.HasValue)
                ButtonSalvar.IsEnabled = false;
            else
                ButtonSalvar.IsEnabled = true;

            this.DataContext = emprestimo;
        }

        private void ToggleEmprestimoDataAtual_Toggled(object sender, RoutedEventArgs e)
        {
            if (ToggleEmprestimoDataAtual != null)
            {
                if (ToggleEmprestimoDataAtual.IsOn)
                    TextBoxData.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                else
                    TextBoxData.Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
        }

        private void ButtonSelecionarUsuario_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.SelecionaUsuarioPage),  new ViewModel.UsuarioViewModel());
           
        }

        private void ButtonSalvar_Click(object sender, RoutedEventArgs e)
        {
            Model.Emprestimo emprestimo = (Model.Emprestimo)((AppBarButton)e.OriginalSource).CommandParameter;

            if (ToggleEmprestimoDataAtual.IsOn)
                emprestimo.DataEmprestimo = DateTime.Now;
            else
            {
                DateTime data;
                if (DateTime.TryParse(TextBoxData.Text, out data))
                    emprestimo.DataEmprestimo = data;
                else
                    throw new Exception("Data invalida");
            }

            this.EmprestimoViewModel.EmprestarLivro.Execute(emprestimo);
        }
    }
}
