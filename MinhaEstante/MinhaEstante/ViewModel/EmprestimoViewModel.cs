﻿using System;
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

            ListaDeEmprestimosAtivos = ListaDeEmprestimos.Where(i => !i.DataDevolucao.HasValue).ToList();

            SalvarEmprestimo = new ViewModel.DelegateCommand<Model.Emprestimo>(Salvar);
            DevolverLivro = new ViewModel.DelegateCommand<Model.Emprestimo>(Devolver);
            VisualizarEmprestimo = new ViewModel.DelegateCommand<Model.Emprestimo>(Visualizar); 

        }

        public Model.Emprestimo SelectedEmprestimo { get; set; }

        public ObservableCollection<Model.Emprestimo> ListaDeEmprestimos { get; private set; }

        public List<Model.Emprestimo> ListaDeEmprestimosAtivos { get; private set; }

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

        public ICommand VisualizarEmprestimo { get; set; }
        public void Visualizar(Model.Emprestimo emprestimo)
        {
            SelectedEmprestimo = emprestimo;

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.NovoEmprestimoPage), this);

        }

        public ICommand DevolverLivro { get; set; }
        public void Devolver(Model.Emprestimo emprestimo)
        {
            emprestimo.DataDevolucao = DateTime.Now;

            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Emprestimo>();
            }

            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.InsertOrReplace(emprestimo) > 0)
                {
                    int index = this.ListaDeEmprestimos.IndexOf(emprestimo);
                    if (index > -1)
                        this.ListaDeEmprestimos[index] = emprestimo;
                    else
                        this.ListaDeEmprestimos.Add(emprestimo);
                }
            }

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.PivotPage));

        }

        public ICommand SalvarEmprestimo { get; set; }
        private void Salvar(Model.Emprestimo emprestimo)
        {
            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                db.CreateTable<Model.Emprestimo>();
            }

            using (var db = new SQLite.SQLiteConnection(DB_PATH))
            {
                if (db.InsertOrReplace(emprestimo) > 0)
                {
                    int index = this.ListaDeEmprestimos.IndexOf(emprestimo);
                    if (index > -1)
                        this.ListaDeEmprestimos[index] = emprestimo;
                    else
                        this.ListaDeEmprestimos.Add(emprestimo);
                }
            }

            Frame rootFrame = Window.Current.Content as Frame;
            rootFrame.Navigate(typeof(View.PivotPage));
        }

        public IList<Model.Emprestimo> ListarTodosEmprestimos(int codigoLivro)
        {
            return ListaDeEmprestimos.Where(i => i.CodigoLivro == codigoLivro).ToList();
        }

    }
}
