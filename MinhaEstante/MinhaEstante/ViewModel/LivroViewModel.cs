using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace MinhaEstante.ViewModel
{
    public class LivroViewModel
    {
        public static string DB_PATH = string.Format(@"{0}\{1}", ApplicationData.Current.LocalFolder.Path, "DB.MinhaEstante");

        public LivroViewModel()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Livro>();
            }

            ListaDeLivros = GetAllLivros();

            DeleteLivro = new ViewModel.DelegateCommand<Model.Livro>(Delete);
            UpdateLivro = new ViewModel.DelegateCommand<Model.Livro>(Update);
            EditLivro = new ViewModel.DelegateCommand<Model.Livro>(Edit);
        }

        public ObservableCollection<Model.Livro> ListaDeLivros { get; private set; }

        public ObservableCollection<Model.Livro> GetAllLivros()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                return new ObservableCollection<Model.Livro>(db.Table<Model.Livro>());
            }
        }

        public Model.Livro SelectedLivro { get; set; }

        public ICommand DeleteLivro { get; set; }
        private void Delete(Model.Livro Livro)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.Delete(Livro) > 0)
                    ListaDeLivros.Remove(Livro);
            }
        }

        public ICommand UpdateLivro { get; set; }
        private void Update(Model.Livro Livro)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Livro>();
            }

            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.InsertOrReplace(Livro) > 0)
                {
                    int index = this.ListaDeLivros.IndexOf(Livro);
                    if (index > -1)
                        this.ListaDeLivros[index] = Livro;
                    else
                        this.ListaDeLivros.Add(Livro);
                }
            }

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.GoBack();
        }

        public ICommand EditLivro { get; set; }
        public void Edit(Model.Livro Livro)
        {
            SelectedLivro = Livro;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoLivroPage), this);

        }
    }
}
