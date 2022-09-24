using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos
{
    internal class Animal
    {
        public string Familia { get; set; }
        public string Raca { get; set; }
        public string Nome { get; set; }
        public char Sexo { get; set; }
        public string Situacao { get; set; }

        public Animal()
        {

        }
        public Animal(string familia, char sexo) // para criar um novo cadastro com apenas esses dados necessarios e então editar os restantes no update ou no Insert
        {
            Familia = familia;
            Sexo = sexo;
        }

        public Animal(string familia, string raca, string nome, char sexo, string situacao) // caso necessario criar um preenchido totalmente vindo de um registro do banco
        {
            Familia = familia;
            Raca = raca;
            Nome = nome;
            Sexo = sexo;
            Situacao = situacao;
        }
    }
}
