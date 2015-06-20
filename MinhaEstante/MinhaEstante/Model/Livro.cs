using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    class Livro
    {
        public string Titulo { get; set; }
        public Autor Autor { get; set; }
        public Editora Editora { get; set; }
        public int Edicao { get; set; }
        public bool Emprestado { get; set; }
        public bool Lido { get; set; }
        public bool Favorito { get; set; }

        public Livro()
        {
        }

        public Livro(bool emprestado, bool lido)
        {
            Emprestado = emprestado;
            Lido = lido;
        }
    }
}
