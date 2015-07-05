using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    [SQLite.Table("Emprestimo")]
    public class Emprestimo
    {
        private Livro _livro;
        private Usuario _usuario;

        [SQLite.Column("ID")]
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int? ID { get; set; }

        [SQLite.Column("CodigoLivro")]
        public int CodigoLivro { get; set; }

        [SQLite.Column("CodigoUsuario")]
        public int CodigoUsuario { get; set; }

        [SQLite.Column("DataEmprestimo")]
        [SQLite.NotNull]
        public DateTime DataEmprestimo { get; set; }

        [SQLite.Column("DataDevolucao")]
        public DateTime? DataDevolucao { get; set; }

        [SQLite.Ignore]
        public Livro Livro
        {
            get 
            {
                if (_livro == null)
                    _livro = (new ViewModel.LivroViewModel()).ObterLivroPorCodigo(CodigoLivro);
                return _livro; 
            }
            set { _livro = value; }
        }

        [SQLite.Ignore]
        public Usuario Usuario
        {
            get
            {
                if (_usuario == null)
                    _usuario = (new ViewModel.UsuarioViewModel()).ObterUsuarioPorCodigo(CodigoUsuario);
                return _usuario;
            }
            set { _usuario = value; }
        }
    }
}
