using System;
using System.Data.SqlClient;

namespace Proj_ONG_ResGatinhos
{
    internal class Program
    {
        #region TELAS
        public static void Tela_Inicial(Banco_De_Dados conn, SqlConnection conexaoSql) // OK
        {
            conexaoSql.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("Bem Vindo à ONG ResGatinhos!");
                Console.WriteLine("Escolha a Opção desejada para continuar:\n");
                Console.Write(" 1 - Acesso aos 'ADOTANTES'\n");
                Console.Write(" 2 - Acesso aos 'PETS'\n");
                Console.Write(" 3 - Acesso à 'Area de ADOÇÃO'\n");
                Console.Write(" 0 - Encerrar Sessão\n");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            Console.Clear();
                            conexaoSql.Close();
                            Console.WriteLine("\n\n\n\t\t\tObrigado pela sua Cãopanhia!!!\n\t\t\tContinue com os ResGatinhos por aí!!!\n\n\n");
                            Console.WriteLine("\t\t\t......Encerrando Sessão......");
                            Environment.Exit(0);
                            break;

                        case 1:

                            Tela_Adotantes();

                            break;

                        case 2:

                            Tela_Pets();

                            break;

                        case 3:

                            Tela_Adocao();

                            break;

                        default:
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Escolha um valor numérico que represente a opção desejada!\n");
                    Pausa();
                }
            } while (true);
        }
        public static void Tela_Adotantes() // OnProgress
        {

        }
        public static void Tela_Pets() // OnProgress
        {

        }
        public static void Tela_Adocao() // OnProgress
        {

        }
        #endregion
        static void Pausa() // OK
        {
            Console.WriteLine("Aperte [- ENTER -] para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        static void Main(string[] args)
        {
            //Conexão para o Banco de Dados:
            Banco_De_Dados conn = new Banco_De_Dados();
            SqlConnection conexaoSql = new SqlConnection(conn.Caminho());

            Tela_Inicial(conn, conexaoSql);
        }
    }
}
