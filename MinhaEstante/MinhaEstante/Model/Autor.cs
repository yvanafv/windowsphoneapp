using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinhaEstante.Model
{
    public class Autor
    {
        public string Nome { get; set; }
        public List<Editora> Editoras { get; set; }
        public List<Livro> Livros { get; set; }

        public Autor()
        {
        }

        public Autor(string nome, List<Editora> editoras, List<Livro> livros)
        {
            Nome = nome;
            Editoras = editoras;
            Livros = livros;
        }
    }
}
