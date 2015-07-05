using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MinhaEstante.ViewModel
{
    public class EmprestimoViewModel
    {
        public static string DB_PATH = string.Format(@"{0}\{1}", Windows.Storage.ApplicationData.Current.LocalFolder.Path, "DB.MinhaEstante");

        public EmprestimoViewModel()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Emprestimo>();
            }

            ListaDeEmprestimos = GetAllEmprestimos();

        }

        public Model.Emprestimo SelectedEmprestimo { get; set; }

        public ObservableCollection<Model.Emprestimo> ListaDeEmprestimos { get; private set; }

        public ObservableCollection<Model.Emprestimo> GetAllEmprestimos()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                return new ObservableCollection<Model.Emprestimo>(db.Table<Model.Emprestimo>());
            }
        }

        public ICommand EmprestarLivro { get; set; }
        public void Emprestar(Model.Emprestimo Emprestimo)
        {
            SelectedEmprestimo = Emprestimo;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoEmprestimoPage), this);

        }

        public ICommand DevolverLivro { get; set; }
        public void Devolver(Model.Emprestimo Emprestimo)
        {
            SelectedEmprestimo = Emprestimo;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoEmprestimoPage), this);

        }

        public IList<Model.Emprestimo> ObterEmprestimoPorLivro(int codigoLivro)
        {
            return ListaDeEmprestimos.Where(i => i.CodigoLivro == codigoLivro).ToList();
        }
    }
}
