using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaEstante.Model
{
    class Usuario
    {
        public string nome { get; set; }
        public string email { get; set; }
        public List<Livro> livro { get; set; }
    }
}
