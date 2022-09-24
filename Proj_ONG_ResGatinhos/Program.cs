using System;
using System.Data.SqlClient;

namespace Proj_ONG_ResGatinhos
{
    internal class Program
    {
        #region TELAS
        public static void Tela_Inicial(SqlConnection connection) // OK
        {
            connection.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("Bem Vindo à ResGatinhos!");
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
                            connection.Close();
                            Console.WriteLine("\n\n\n\t\t\tObrigado pela sua Cãopanhia!!!\n\t\t\tContinue com os ResGatinhos por aí!!!\n\n\n");
                            Console.WriteLine("\t\t\t......Encerrando Sessão......");
                            Environment.Exit(0);
                            break;

                        case 1:
                            connection.Close();
                            Tela_Adotantes(connection);

                            break;

                        case 2:
                            connection.Close();
                            Tela_Pets(connection);

                            break;

                        case 3:
                            connection.Close();
                            Tela_Adocao(connection);

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
        public static void Tela_Adotantes(SqlConnection connection) // OnProgress
        {
            connection.Open();
            do
            {       
                int opc;
                Console.Clear();
                Console.WriteLine("ADOTANTES");
                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine(" 1 - Ver todos Cadastrados");
                Console.WriteLine(" 2 - Cadastrar um Novo");
                Console.WriteLine(" 3 - Editar um Cadastro já Existente");
                Console.WriteLine(" 4 - Ver Histórico de Adoção de um já Cadastrado");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            connection.Close();
                            Tela_Inicial(connection);
                            break;

                        case 1:
                            connection.Close();
                            MostrarAdotantesCadastrados(connection);
                            break;

                        case 2:
                            connection.Close();

                            break;

                        case 3:
                            connection.Close();

                            break;

                        case 4:
                            connection.Close();

                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (true);
        }
        public static void Tela_Pets(SqlConnection connection) // OnProgress
        {

        }
        public static void Tela_Adocao(SqlConnection connection) // OnProgress
        {

        }
        #endregion
        #region FUNCTIONS
        static void MostrarAdotantesCadastrados(SqlConnection connection) // OK
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CPF, Nome, Sexo, Data_Nascimento, Telefone, Cidade, Estado, Bairro, Rua, Numero, Complemento FROM Pessoa;";
            cmd.Connection = connection;
            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.Clear();
                Console.WriteLine("\nLista de Adotantes cadastrados:");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                Console.WriteLine("CPF  |   Nome  |     Sexo  |     Data de Nascimento  |   Telefone  |     Endereço");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                while (reader.Read())
                {
                    string dataNascimento =      reader.GetDateTime(3).ToString("dd-MM-yyyy");
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.Write("{0}" , /*cpf*/reader.GetString(0) + "    |    " +
                                         /*nome*/reader.GetString(1) + "    |    " +
                                         /*sexo*/reader.GetString(2) + "    |    " +
                                     /*dataNasc*/dataNascimento      + "    |    " +
                                     /*telefone*/reader.GetString(4) + "    |    " +
                                       /*cidade*/reader.GetString(5) + "    |    " +
                                       /*Estado*/reader.GetString(6) + "    |    " +
                                       /*bairro*/reader.GetString(7) + "    |    " +
                                       /*rua*/   reader.GetString(8) + "    |    " +
                                       /*numero*/reader.GetInt32 (9) + "    |    " +
                                  /*complemento*/reader.GetString(10)+ "    |    \n");
                    Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                }
                Console.WriteLine("Fim da Lista");
                Pausa();
                connection.Close();
                Tela_Adotantes(connection);
            }
        }
        static void Pausa() // OK
        {
            Console.WriteLine("Aperte [- ENTER -] para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        #endregion
        static void Main(string[] args)
        {
            //Conexão para o Banco de Dados:
            Banco_De_Dados conn = new Banco_De_Dados();
            SqlConnection connection = new SqlConnection(conn.Caminho());

            Tela_Inicial(connection);

        }
    }
}
