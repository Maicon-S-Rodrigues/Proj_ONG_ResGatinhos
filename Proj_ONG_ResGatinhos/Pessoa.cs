using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos
{
    internal class Pessoa
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }

        public Pessoa ()
        {

        }

        public Pessoa(string cpf, string nome, string sexo, DateTime dataNascimento, string telefone, string estado, string cidade, string bairro, string rua, int numero, string complemento)
        {
            CPF = cpf;
            Nome = nome;
            Sexo = sexo;
            DataNascimento = dataNascimento;
            Telefone = telefone;
            Estado = estado;
            Cidade = cidade;
            Bairro = bairro;
            Rua = rua;
            Numero = numero;
            Complemento = complemento;
        }
    }
}
