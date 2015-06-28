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
        //public Editora Editora { get; set; }
        //public int Edicao { get; set; }
        //public bool Emprestado { get; set; }
        //public bool Lido { get; set; }
        //public bool Favorito { get; set; }
        //public Usuario Usuario { get; set; }

        public Livro()
        {
        }

        public Livro(string titulo, string autor)
        {
            this.Titulo = titulo;
            this.Autor = autor;
        }

        //public Livro(string titulo, string autor, Editora editora, int edicao, bool emprestado, bool lido, bool favorito, Usuario usuario)
        //{
        //    Titulo = titulo;
        //    Autor = autor;
        //    Editora = editora;
        //    Edicao = edicao;
        //    Emprestado = emprestado;
        //    Lido = lido;
        //    Favorito = favorito;
        //    Usuario = usuario;
        //}
    }
}
