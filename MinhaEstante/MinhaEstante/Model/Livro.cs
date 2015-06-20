using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    class Livro
    {
        public string nome { get; set; }
        public Editora editora { get; set; }
        public bool emprestado { get; set; }
        public bool lido { get; set; }

        public Livro()
        {
            this.emprestado = false;
            this.lido = false;
        }
    }
}
