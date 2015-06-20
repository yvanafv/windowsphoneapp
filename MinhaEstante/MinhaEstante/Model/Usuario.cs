using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Livro> Livro { get; set; }

        public Usuario(string nome, string email, List<Livro> livro)
        {
            this.Nome = nome;
            this.Email = email;
            this.Livro = livro;
        }
    }
}
