using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    class Livro
    {
        public string Nome { get; set; }
        public Editora Editora { get; set; }
        public bool Emprestado { get; set; }
        public bool Lido { get; set; }

        public Livro(bool emprestado, bool lido)
        {
            Emprestado = emprestado;
            Lido = lido;
        }
    }
}
