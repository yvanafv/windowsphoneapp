using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    [SQLite.Table("Livro")]
    public class Livro
    {
        [SQLite.Column("ID")]
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int? ID { get; set; }

        [SQLite.Column("Titulo")]
        [SQLite.MaxLength(100)]
        public string Titulo { get; set; }

        [SQLite.Column("Autor")]
        [SQLite.MaxLength(100)]
        public string Autor { get; set; }

        private bool _emprestado;

        [SQLite.Ignore]
        public bool Emprestado
        {
            get
            {
                if (ID.HasValue)
                {
                    var emprestimos = (new ViewModel.EmprestimoViewModel()).ListarTodosEmprestimos(ID.Value);
                    if (emprestimos != null)
                        _emprestado = emprestimos.Any(i => !i.DataDevolucao.HasValue);
                }
                return _emprestado;
            }
            set { _emprestado = value; }
        }

        private List<Emprestimo> _historicoEmprestimos;

        [SQLite.Ignore]
        public List<Emprestimo> HistoricoEmprestimos
        {
            get
            {
                if (_historicoEmprestimos == null)
                {
                    _historicoEmprestimos = (new ViewModel.EmprestimoViewModel()).ListarTodosEmprestimos(ID.Value).ToList();
                }
                return _historicoEmprestimos;
            }
            set { _historicoEmprestimos = value; }
        }

        [SQLite.Column("Lido")]
        public bool Lido { get; set; }

        [SQLite.Column("Favorito")]
        public bool Favorito { get; set; }

        public Livro()
        {
        }

        public Livro(string titulo, string autor, bool emprestado, bool lido, bool favorito)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Emprestado = emprestado;
            this.Lido = lido;
            this.Favorito = favorito;
        }
    }
}
