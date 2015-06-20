using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    public class Livro
    {
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public Editora Editora { get; set; }
        public int Edicao { get; set; }
        public bool Emprestado { get; set; }
        public bool Lido { get; set; }
        public bool Favorito { get; set; }
        public Usuario Usuario { get; set; }

        public Livro()
        {
        }

        public Livro(string titulo, Autor autor, Editora editora, int edicao, bool emprestado, bool lido, bool favorito, Usuario usuario)
        {
            Titulo = titulo;
            Autor = autor;
            Editora = editora;
            Edicao = edicao;
            Emprestado = emprestado;
            Lido = lido;
            Favorito = favorito;
            Usuario = usuario;
        }
    }
}
