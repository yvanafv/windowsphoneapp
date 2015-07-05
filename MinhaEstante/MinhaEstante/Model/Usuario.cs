using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    [SQLite.Table("Usuario")]
    public class Usuario
    {
        [SQLite.Column("ID")]
        [SQLite.PrimaryKey]
        [SQLite.AutoIncrement]
        public int? ID { get; set; }

        [SQLite.Column("Nome")]
        [SQLite.MaxLength(100)]
        [SQLite.NotNull]
        public string Nome { get; set; }

        [SQLite.Column("Email")]
        [SQLite.MaxLength(100)]
        public string Email { get; set; }

        [SQLite.Column("Senha")]
        [SQLite.MaxLength(100)]
        public string Senha { get; set; }
        //public List<Livro> Livros { get; set; }

        public Usuario()
        {
        }

        public Usuario(string nome, string senha)
        {
            this.Nome = nome;
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
