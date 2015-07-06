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

            Windows.Storage.ApplicationDataContainer roamingSettings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            ViewModel.EmprestimoViewModel emprestimo = new ViewModel.EmprestimoViewModel();
            emprestimo.SelectedEmprestimo = new Model.Emprestimo();
            if (e.Parameter.GetType() == typeof(ViewModel.EmprestimoViewModel))
            {
                emprestimo = (ViewModel.EmprestimoViewModel)e.Parameter;
                roamingSettings.Values["Livro"] = emprestimo.SelectedEmprestimo.Livro.ID.Value;
            }
            else
            {
                if (roamingSettings.Values.ContainsKey("Livro"))
                {
                    var codigoLivro = Convert.ToInt32(roamingSettings.Values["Livro"].ToString());
                    emprestimo.SelectedEmprestimo.Livro = (new ViewModel.LivroViewModel()).ObterLivroPorCodigo(codigoLivro);
                }
                emprestimo.SelectedEmprestimo.Usuario = (Model.Usuario)e.Parameter;
            }
                 
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
            this.EmprestimoViewModel = new ViewModel.EmprestimoViewModel();
            
            Model.Emprestimo emprestimo = (Model.Emprestimo)((AppBarButton)e.OriginalSource).CommandParameter;
            emprestimo.CodigoLivro = emprestimo.Livro.ID.Value;
            emprestimo.CodigoUsuario = emprestimo.Usuario.ID.Value;

            if (this.EmprestimoViewModel.ListaDeEmprestimosAtivos.Exists(i => i.Livro.ID == emprestimo.CodigoLivro))
                MessageBox.Show("Livro está emprestado.");
            else
            {
                if (emprestimo.Usuario == null)
                    MessageBox.Show("Selecione um usuário.");
                else
                {
                    if (ToggleEmprestimoDataAtual.IsOn)
                        emprestimo.DataEmprestimo = DateTime.Now;
                    else
                    {
                        DateTime data;
                        if (DateTime.TryParse(TextBoxData.Text, out data))
                            emprestimo.DataEmprestimo = data;
                        else
                            MessageBox.Show("Data inválida");
                    }

                    this.EmprestimoViewModel.SalvarEmprestimo.Execute(emprestimo);
                }
            }
        }

        private void ButtonVoltar_Click(object sender, RoutedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }
    }
}
