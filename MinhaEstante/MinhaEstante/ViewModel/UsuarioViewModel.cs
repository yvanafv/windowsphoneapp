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
    public class UsuarioViewModel
    {
        public static string DB_PATH = string.Format(@"{0}\{1}", ApplicationData.Current.LocalFolder.Path, "DB.MinhaEstante");

        public UsuarioViewModel()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Usuario>();
            }

            ListaDeUsuarios = GetAllUsuario().Where(i => String.IsNullOrEmpty(i.Senha)).ToList();

            ListaDeUsuariosComSenha = GetAllUsuario().Where(i => !String.IsNullOrEmpty(i.Senha)).ToList();

            DeleteUsuario = new ViewModel.DelegateCommand<Model.Usuario>(Delete);
            UpdateUsuario = new ViewModel.DelegateCommand<Model.Usuario>(Update);
            EditUsuario = new ViewModel.DelegateCommand<Model.Usuario>(Edit);
            SalvarUsuarioAcesso = new ViewModel.DelegateCommand<Model.Usuario>(Salvar);
            LoginUsuario = new ViewModel.DelegateCommand<Model.Usuario>(Logar);
        }

        public List<Model.Usuario> ListaDeUsuarios { get; private set; }
        public List<Model.Usuario> ListaDeUsuariosComSenha { get; private set; }

        public ObservableCollection<Model.Usuario> GetAllUsuario()
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                return new ObservableCollection<Model.Usuario>(db.Table<Model.Usuario>());
            }
        }

        public Model.Usuario SelectedUsuario { get; set; }

        public ICommand DeleteUsuario { get; set; }
        private void Delete(Model.Usuario Usuario)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.Delete(Usuario) > 0)
                    ListaDeUsuarios.Remove(Usuario);
            }
        }

        public ICommand UpdateUsuario { get; set; }
        private void Update(Model.Usuario Usuario)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.InsertOrReplace(Usuario) > 0)
                {
                    int index = this.ListaDeUsuarios.IndexOf(Usuario);
                    if (index > -1)
                        this.ListaDeUsuarios[index] = Usuario;
                    else
                        this.ListaDeUsuarios.Add(Usuario);
                }
            }

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.SelecionaUsuarioPage), this);
        }

        public ICommand SalvarUsuarioAcesso { get; set; }
        private void Salvar(Model.Usuario usuario)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.InsertOrReplace(usuario) > 0)
                {
                    int index = this.ListaDeUsuarios.IndexOf(usuario);
                    if (index > -1)
                        this.ListaDeUsuarios[index] = usuario;
                    else
                        this.ListaDeUsuarios.Add(usuario);
                }
            }

            SelectedUsuario = usuario;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.MainPage), this);
        }

        public ICommand EditUsuario { get; set; }
        public void Edit(Model.Usuario Usuario)
        {
            SelectedUsuario = Usuario;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoUsuarioPage), this);
        }

        public ICommand LoginUsuario { get; set; }
        public void Logar(Model.Usuario usuario)
        {
            if (ListaDeUsuariosComSenha.Any(i => i.Nome == usuario.Nome && i.Senha == usuario.Senha))
            {
                Frame rootFrame = Window.Current.Content as Frame;
                rootFrame.Navigate(typeof(View.PivotPage), usuario);
            }
            else
                throw new Exception("Usuário ou senha inválidos.");
        }

        public Model.Usuario ObterUsuarioPorCodigo(int codigo)
        {
            return ListaDeUsuarios.Where(i => i.ID == codigo).FirstOrDefault();
        }
    }
}
