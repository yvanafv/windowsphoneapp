using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    public class Editora
    {
        public string Nome { get; set; }
        public List<Autor> Autores { get; set; }

        public Editora()
        {
        }

        public Editora(string nome, List<Autor> autores)
        {
            Nome = nome;
            Autores = autores;
        }
    }
}
