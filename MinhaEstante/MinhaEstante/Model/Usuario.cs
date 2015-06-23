using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    public class Usuario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public List<Livro> Livros { get; set; }

        public Usuario()
        {
        }

        public Usuario(string email, string senha)
        {
            this.Email = email;
            this.Senha = senha;
        }

        //Construtor para novo usuário
        public Usuario(string nome, string email, string senha)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
        }
    }
}
