using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj_ONG_ResGatinhos
{
    internal class Banco_De_Dados
    {
        string Conexao = "Data Source=localhost; Initial Catalog=Resgatinhos; User ID=sa; password=Sol@2905;";

        public string Caminho()
        {
            return Conexao;
        }
    }
}
