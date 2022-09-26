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
                Console.WriteLine(" Bem Vindo à ResGatinhos!");
                Console.WriteLine(" Escolha a Opção desejada para continuar:\n");
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
        public static void Tela_Adotantes(SqlConnection connection) // OnProgress... (-faltando os updates-)
        {
            connection.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("ADOTANTES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Ver todos Cadastrados");
                Console.WriteLine(" 2 - Cadastrar um Novo");
                Console.WriteLine(" 3 - Editar um Cadastro já Existente");
                Console.WriteLine(" 4 - Ver Histórico de Adoção de um já Cadastrado");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            connection.Close(); // OK
                            Tela_Inicial(connection);
                            break;

                        case 1:
                            connection.Close();// OK
                            MostrarAdotantesCadastrados(connection);
                            break;

                        case 2:
                            connection.Close(); // OK
                            CadastrarNovoAdotante(connection);
                            break;

                        case 3:
                            connection.Close(); // OnProgress...
                            Console.Clear();
                            Console.WriteLine("\nEDITAR ADOTANTES\n");
                            Console.Write("\nInforme o 'CPF' do Adotante que deseja editar: ");
                            string cpfEditar = Console.ReadLine();
                            EditarAdotante(cpfEditar, connection);
                            break;

                        case 4:
                            connection.Close(); // OK...
                            Console.Clear();
                            Console.WriteLine("ADOTANTES\n");
                            Console.Write("\nInforme o 'CPF' do Adotante para ver quais Animais ele adotou: ");
                            string cpfPesquisa = Console.ReadLine();
                            MostrarAnimaisAdotadosPeloCPF(cpfPesquisa, connection);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (true);
        }
        public static void Tela_Pets(SqlConnection connection) // OnProgress... (-faltando os updates-)
        {
            connection.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("PETS\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Cadastrar um novo PET");
                Console.WriteLine(" 2 - Editar os dados de um já cadastrado");
                Console.WriteLine(" 3 - Ver a Lista de Pets Disponíveis para Adoção");
                Console.WriteLine(" 4 - Ver a Lista de Pets já Adotados");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            connection.Close(); // OK
                            Tela_Inicial(connection);
                            break;

                        case 1:
                            connection.Close();// OK
                            CadastrarNovoPet(connection);
                            break;

                        case 2:
                            connection.Close(); // OnProgress...
                            break;

                        case 3:
                            connection.Close(); // OK
                            MostrarPetsDisponiveis(connection);
                            break;

                        case 4:
                            connection.Close(); // OK
                            MostrarPetsAdotados(connection);
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
        public static void Tela_Adocao(SqlConnection connection) // OK
        {
            connection.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("ADOÇÕES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Realizar uma nova Adoção");
                Console.WriteLine(" 2 - Dezfazer uma Adoção");
                Console.WriteLine(" 3 - Ver a Lista de Adotantes e seus respectivos Pets");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            connection.Close(); // OK
                            Tela_Inicial(connection);
                            break;

                        case 1:
                            connection.Close();// OK
                            CadastrarNovaAdocao(connection);
                            break;

                        case 2:
                            connection.Close(); // OK
                            DesfazerUmaAdocao(connection);
                            break;

                        case 3:
                            connection.Close(); // OK
                            MostrarAdotantesESeusPets(connection);
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
        #endregion

        #region FUNCTIONS - ADOTANTES
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
                    string dataNascimento = reader.GetDateTime(3).ToString("dd-MM-yyyy");
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.Write("{0}", /*cpf*/reader.GetString(0) + "    |    " +
                                         /*nome*/reader.GetString(1) + "    |    " +
                                         /*sexo*/reader.GetString(2) + "    |    " +
                                     /*dataNasc*/dataNascimento + "    |    " +
                                     /*telefone*/reader.GetString(4) + "    |    " +
                                       /*cidade*/reader.GetString(5) + "    |    " +
                                       /*Estado*/reader.GetString(6) + "    |    " +
                                       /*bairro*/reader.GetString(7) + "    |    " +
                                       /*rua*/   reader.GetString(8) + "    |    " +
                                       /*numero*/reader.GetInt32(9) + "    |    " +
                                  /*complemento*/reader.GetString(10) + "    |    \n");
                    Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                }
                Console.WriteLine("Fim da Lista");
                Pausa();
                connection.Close();
                Tela_Adotantes(connection);
            }
        }
        static void CadastrarNovoAdotante(SqlConnection connection) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Pessoa (CPF, Nome, Sexo, Data_Nascimento, Telefone, Cidade, Estado, Bairro, Rua, Numero, Complemento)" +
                              "VALUES (@CPF, @Nome, @Sexo, @Data_Nascimento, @Telefone, @Cidade, @Estado, @Bairro, @Rua, @Numero, @Complemento);";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);
            SqlParameter SQLnome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLsexo = new SqlParameter("@Sexo", System.Data.SqlDbType.Char, 1);
            SqlParameter SQLdataNasc = new SqlParameter("@Data_Nascimento", System.Data.SqlDbType.Date);
            SqlParameter SQLtelefone = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar, 12);
            SqlParameter SQLcidade = new SqlParameter("@Cidade", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLestado = new SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 30);
            SqlParameter SQLbairro = new SqlParameter("@Bairro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLrua = new SqlParameter("@Rua", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLnumero = new SqlParameter("@Numero", System.Data.SqlDbType.Int);
            SqlParameter SQLcomplemento = new SqlParameter("@Complemento", System.Data.SqlDbType.VarChar, 50);
            //___________________________________________________________________________________________________________________________________________________________
            //variaveis locais
            string cpf, nome, sexo, telefone, cidade, estado, bairro, rua, complemento;
            DateTime dataNasc;
            int numero;

            Console.WriteLine("CADASTRO DE ADOTANTE\n\n");
            Console.Write("\nInforme o CPF para começar: ");
            cpf = Console.ReadLine();

            Console.Write("\nNome: ");
            nome = Console.ReadLine();


            bool flag = false;
            do
            {
                Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não queira informar");
                Console.Write("\nSexo: ");
                sexo = Console.ReadLine().ToUpper();
                if (sexo.ToUpper() == "F" || sexo.ToUpper() == "M" || sexo.ToUpper() == "N")
                {
                    flag = true;
                    break;
                }
            } while (flag == false);


            Console.Write("\nData de Nascimento (dd/MM/yyy): ");
            dataNasc = LerData();

            Console.Write("\nTelefone: ");
            telefone = Console.ReadLine();

            Console.Write("\n\nENDEREÇO");
            Console.Write("\nCidade: ");
            cidade = Console.ReadLine();

            Console.Write("\nEstado (U-F): ");
            estado = Console.ReadLine();

            Console.Write("\nBairro: ");
            bairro = Console.ReadLine();

            Console.Write("\nRua: ");
            rua = Console.ReadLine();

            Console.Write("\nNúmero: ");
            numero = LerNumero();

            Console.Write("\nComplemento: ");
            complemento = Console.ReadLine();

            Pessoa P = new Pessoa(cpf, nome, sexo, dataNasc, telefone, estado, cidade, bairro, rua, numero, complemento);
            //___________________________________________________________________________________________________________________________________________________________

            SQLcpf.Value = P.CPF;
            SQLnome.Value = P.Nome;
            SQLsexo.Value = P.Sexo;
            SQLdataNasc.Value = P.DataNascimento;
            SQLtelefone.Value = P.Telefone;
            SQLcidade.Value = P.Cidade;
            SQLestado.Value = P.Estado;
            SQLbairro.Value = P.Bairro;
            SQLrua.Value = P.Rua;
            SQLnumero.Value = P.Numero;
            SQLcomplemento.Value = P.Complemento;

            cmd.Parameters.Add(SQLcpf);
            cmd.Parameters.Add(SQLnome);
            cmd.Parameters.Add(SQLsexo);
            cmd.Parameters.Add(SQLdataNasc);
            cmd.Parameters.Add(SQLtelefone);
            cmd.Parameters.Add(SQLcidade);
            cmd.Parameters.Add(SQLestado);
            cmd.Parameters.Add(SQLbairro);
            cmd.Parameters.Add(SQLrua);
            cmd.Parameters.Add(SQLnumero);
            cmd.Parameters.Add(SQLcomplemento);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("\nCadastro Realizado com Sucesso!!!");
            Pausa();
            connection.Close();
        }
        static void MostrarAnimaisAdotadosPeloCPF(string cpfPesquisa, SqlConnection connection) // OK
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                cmd.CommandText = "SELECT Pessoa.CPF, Pessoa.Nome, Animal.Familia, Animal.Nome, Animal.Raca, Animal.Situacao " +
                  "FROM Adota " +

                  "RIGHT JOIN Pessoa " +

                  "ON(Pessoa.CPF = Adota.CPF) " +

                  "RIGHT JOIN Animal " +

                  "ON(Animal.CHIP = Adota.CHIP) " +

                  "WHERE Pessoa.CPF = @CPF; ";

                cmd.Connection = connection;
                connection.Open();

                SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);
                SQLcpf.Value = cpfPesquisa;

                cmd.Parameters.Add(SQLcpf);

                cmd.Prepare();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.Clear();
                    Console.WriteLine("\nLista de Animais Adotados pelo adotante com o 'CPF': " + cpfPesquisa);
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.WriteLine("|  CPF  |   Nome   |   Animal   |    Nome do Pet   |   Raça  |   Status     |");
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                    while (reader.Read())
                    {
                        Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                        Console.Write("{0}",  /*cpf*/reader.GetString(0) + "    |    " +
                                             /*nome*/reader.GetString(1) + "    |    " +
                                           /*animal*/reader.GetString(2) + "    |    " +
                                      /*nome do pet*/reader.GetString(3) + "    |    " +
                                             /*raça*/reader.GetString(4) + "    |    " +
                                           /*Status*/reader.GetString(5) + "    |    \n");
                        Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                    }
                    Console.WriteLine("Fim da Lista");
                    Pausa();
                    connection.Close();
                    Tela_Adotantes(connection);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("\n\nNão foi possível realizar essa busca, tente novamente.\n" +
                                  "Certifique-se de que o 'CPF' informado para busca foi digitado corretamente");
                Pausa();
                connection.Close();
                Tela_Adotantes(connection);
            }
        }
        #region EDITAR - ADOTANTES
        static void EditarAdotante(string cpfEditar, SqlConnection connection) // OK
        {
            connection.Open();
            do
            {
                int opc;
                Console.Clear();
                Console.WriteLine("EDITAR ADOTANTES\n");
                Console.WriteLine(" O que deseja fazer?");
                Console.WriteLine(" 1 - Editar Nome");
                Console.WriteLine(" 2 - Editar Telefone");
                Console.WriteLine(" 3 - Editar Sexo");
                Console.WriteLine(" 4 - Editar Endereço");
                Console.WriteLine(" 5 - Editar Data de Nascimento");
                Console.WriteLine(" 0 - Voltar");
                try
                {
                    opc = int.Parse(Console.ReadLine());
                    switch (opc)
                    {
                        case 0:
                            connection.Close(); // OK
                            Tela_Adotantes(connection);
                            break;

                        case 1:
                            connection.Close();// OK
                            EditarNomeAdotante(cpfEditar, connection);
                            break;

                        case 2:
                            connection.Close(); // OK
                            EditarTelefoneAdotante(cpfEditar, connection);
                            break;

                        case 3:
                            connection.Close(); // OK
                            EditarSexoAdotante(cpfEditar, connection);
                            break;

                        case 4:
                            connection.Close(); // OK
                            EditarEnderecoAdotante(cpfEditar, connection);
                            break;

                        case 5:
                            connection.Close(); // OK
                            EditarDataNascimentoAdotante(cpfEditar, connection);
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
        static void EditarNomeAdotante(string cpfEditar, SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Pessoa SET Nome = @Nome WHERE CPF = @CPF;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLnome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);

            Console.WriteLine("ALTERAR NOME\n\n");

            Console.Write("Informe o Novo Nome a ser inserido: ");
            string nome = Console.ReadLine();

            SQLnome.Value = nome;
            SQLcpf.Value = cpfEditar;

            cmd.Parameters.Add(SQLnome);
            cmd.Parameters.Add(SQLcpf);

            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nNome Alterado com Sucesso!!!");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
        } // OK
        static void EditarTelefoneAdotante(string cpfEditar, SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Pessoa SET Telefone = @Telefone WHERE CPF = @CPF;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLtelefone = new SqlParameter("@Telefone", System.Data.SqlDbType.VarChar, 12);
            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);

            Console.WriteLine("ALTERAR TELEFONE\n\n");

            Console.Write("Informe o Novo Telefone a ser inserido: ");
            string telefone = Console.ReadLine();

            SQLtelefone.Value = telefone;
            SQLcpf.Value = cpfEditar;

            cmd.Parameters.Add(SQLtelefone);
            cmd.Parameters.Add(SQLcpf);

            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nTelefone Alterado com Sucesso!!!");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
        } // OK
        static void EditarSexoAdotante(string cpfEditar, SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Pessoa SET Sexo = @Sexo WHERE CPF = @CPF;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLsexo = new SqlParameter("@Sexo", System.Data.SqlDbType.Char, 1);
            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);

            Console.WriteLine("ALTERAR SEXO\n\n");

            Console.Write("Informe o Novo Sexo a ser inserido: ");
            bool flag = false;
            string sexo;
            do
            {
                Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não queira informar");
                Console.Write("\nSexo: ");
                sexo = Console.ReadLine().ToUpper();
                if (sexo.ToUpper() == "F" || sexo.ToUpper() == "M" || sexo.ToUpper() == "N")
                {
                    flag = true;
                    break;
                }
            } while (flag == false);

            SQLsexo.Value = sexo;
            SQLcpf.Value = cpfEditar;

            cmd.Parameters.Add(SQLsexo);
            cmd.Parameters.Add(SQLcpf);

            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nSexo Alterado com Sucesso!!!");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
        } // OK
        static void EditarEnderecoAdotante(string cpfEditar, SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Pessoa SET Cidade = @Cidade, Estado = @Estado, Bairro = @Bairro, Rua = @Rua, " +
                              "Numero = @Numero, Complemento = @Complemento WHERE CPF = @CPF;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLcidade = new SqlParameter("@Cidade", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLestado = new SqlParameter("@Estado", System.Data.SqlDbType.VarChar, 30);
            SqlParameter SQLbairro = new SqlParameter("@Bairro", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLrua = new SqlParameter("@Rua", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLnumero = new SqlParameter("@Numero", System.Data.SqlDbType.Int);
            SqlParameter SQLcomplemento = new SqlParameter("@Complemento", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);

            string cidade, estado, bairro, rua, complemento;
            int numero;

            Console.WriteLine("ALTERAR ENDEREÇO\n\n");

            Console.Write("Informe o Novo Endereço a ser inserido: ");
            Console.Write("\nCidade: ");
            cidade = Console.ReadLine();

            Console.Write("\nEstado (U-F): ");
            estado = Console.ReadLine();

            Console.Write("\nBairro: ");
            bairro = Console.ReadLine();

            Console.Write("\nRua: ");
            rua = Console.ReadLine();

            Console.Write("\nNúmero: ");
            numero = LerNumero();

            Console.Write("\nComplemento: ");
            complemento = Console.ReadLine();

            SQLcidade.Value = cidade;
            SQLestado.Value = estado;
            SQLbairro.Value = bairro;
            SQLrua.Value = rua;
            SQLnumero.Value = numero;
            SQLcomplemento.Value = complemento;
            SQLcpf.Value = cpfEditar;

            cmd.Parameters.Add(SQLcidade);
            cmd.Parameters.Add(SQLestado);
            cmd.Parameters.Add(SQLbairro);
            cmd.Parameters.Add(SQLrua);
            cmd.Parameters.Add(SQLnumero);
            cmd.Parameters.Add(SQLcomplemento);
            cmd.Parameters.Add(SQLcpf);

            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nEndereço Alterado com Sucesso!!!");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
        } // OK
        static void EditarDataNascimentoAdotante(string cpfEditar, SqlConnection connection)
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Pessoa SET Data_Nascimento = @Data_Nasc WHERE CPF = @CPF;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLdataNasc = new SqlParameter("@Data_Nasc", System.Data.SqlDbType.Date);
            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);

            Console.WriteLine("ALTERAR DATA DE NASCIMENTO\n\n");

            Console.Write("Informe a nova Data de Nascimento a ser inserida: ");
            DateTime dataNasc = LerData();

            SQLdataNasc.Value = dataNasc;
            SQLcpf.Value = cpfEditar;

            cmd.Parameters.Add(SQLdataNasc);
            cmd.Parameters.Add(SQLcpf);

            cmd.Prepare();

            try
            {
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nData de Nascimento Alterada com Sucesso!!!");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                EditarAdotante(cpfEditar, connection);
            }
        } // OK
        #endregion

        #endregion

        #region FUNCTIONS - PETS
        static void CadastrarNovoPet(SqlConnection connection) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Animal (Familia, Raca, Nome, Sexo) " +
                              "VALUES(@Familia, @Raca, @Nome, @Sexo);";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLfamilia = new SqlParameter("@Familia", System.Data.SqlDbType.VarChar, 35);
            SqlParameter SQLraca = new SqlParameter("@Raca", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLnome = new SqlParameter("@Nome", System.Data.SqlDbType.VarChar, 50);
            SqlParameter SQLsexo = new SqlParameter("@Sexo", System.Data.SqlDbType.Char, 1);

            string familia, raca, nome, sexo;

            Console.WriteLine("CADASTRO DE PET\n\n");

            Console.Write("Informe qual Família Animal ele ou ela pertence para começar (Ex: Cachorro, Gato, Passaro, etc)");
            Console.Write("\nFamília Animal: ");
            familia = Console.ReadLine();

            Console.Write("\n(Obs: pode deixar em branco e editar depois caso não seja identificado a princípio)");
            Console.Write("\nRaça: ");
            raca = Console.ReadLine();

            Console.Write("\nNome: ");
            nome = Console.ReadLine();

            bool flag = false;
            do
            {
                Console.Write("\nDigite [- F -] para Feminino, [- M -] para Masculino ou [- N -] caso Não queira ou não saiba informar neste momento");
                Console.Write("\nSexo: ");
                sexo = Console.ReadLine().ToUpper();
                if (sexo.ToUpper() == "F" || sexo.ToUpper() == "M" || sexo.ToUpper() == "N")
                {
                    flag = true;
                    break;
                }
            } while (flag == false);


            Animal A = new Animal(familia, raca, nome, sexo);

            SQLfamilia.Value = A.Familia;
            SQLraca.Value = A.Raca;
            SQLnome.Value = A.Nome;
            SQLsexo.Value = A.Sexo;

            cmd.Parameters.Add(SQLfamilia);
            cmd.Parameters.Add(SQLraca);
            cmd.Parameters.Add(SQLnome);
            cmd.Parameters.Add(SQLsexo);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            Console.Clear();
            Console.WriteLine("\nCadastro Realizado com Sucesso!!!");
            Pausa();
            connection.Close();
        }
        static void MostrarPetsDisponiveis(SqlConnection connection) // OK
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CHIP, Familia, Raca, Nome, Sexo, Situacao FROM Animal WHERE Situacao = 'DISPONIVEL';";
            cmd.Connection = connection;
            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.Clear();
                Console.WriteLine("\nLista de PETS Disponíveis para Adoção:");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                Console.WriteLine("|  CHIP  |  Família  |  Raca  |  Nome  |  Sexo  |  Situação  |");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                while (reader.Read())
                {
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.Write("{0}", /*chip*/reader.GetInt32(0) + "    |    " +
                                      /*familia*/reader.GetString(1) + "    |    " +
                                         /*raca*/reader.GetString(2) + "    |    " +
                                         /*nome*/reader.GetString(3) + "    |    " +
                                         /*sexo*/reader.GetString(4) + "    |    " +
                                     /*situacao*/reader.GetString(5) + "    |    \n");
                    Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                }
                Console.WriteLine("Fim da Lista");
                Pausa();
                connection.Close();
                Tela_Pets(connection);
            }
        }
        static void MostrarPetsAdotados(SqlConnection connection) // OK
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT CHIP, Familia, Raca, Nome, Sexo, Situacao FROM Animal WHERE Situacao = 'ADOTADO';";
            cmd.Connection = connection;
            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                Console.Clear();
                Console.WriteLine("\nLista de PETS já Adotados:");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                Console.WriteLine("|  CHIP  |  Família  |  Raca  |  Nome  |  Sexo  |  Situação  |");
                Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                while (reader.Read())
                {
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.Write("{0}", /*chip*/reader.GetInt32(0) + "    |    " +
                                      /*familia*/reader.GetString(1) + "    |    " +
                                         /*raca*/reader.GetString(2) + "    |    " +
                                         /*nome*/reader.GetString(3) + "    |    " +
                                         /*sexo*/reader.GetString(4) + "    |    " +
                                     /*situacao*/reader.GetString(5) + "    |    \n");
                    Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                }
                Console.WriteLine("Fim da Lista");
                Pausa();
                connection.Close();
                Tela_Pets(connection);
            }
        }
        #endregion

        #region FUNCTIONS - ADOCAO
        static void CadastrarNovaAdocao(SqlConnection connection) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO Adota VALUES(@CPF, @CHIP);";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLcpf = new SqlParameter("@CPF", System.Data.SqlDbType.VarChar, 11);
            SqlParameter SQLchip = new SqlParameter("@CHIP", System.Data.SqlDbType.Int);

            string cpf;
            int chip;

            Console.WriteLine("REGISTRO DE ADOÇÃO\n\n");

            Console.Write("Informe o 'CPF' da pessoa que irá fazer uma adoção: ");
            cpf = Console.ReadLine();

            Console.Write("\nInforme o 'CHIP' de registro do Pet a ser Adotado: ");
            chip = LerNumero();

            SQLcpf.Value = cpf;
            SQLchip.Value = chip;

            cmd.Parameters.Add(SQLcpf);
            cmd.Parameters.Add(SQLchip);

            cmd.Prepare();
            try
            {
                connection.Close();
                FinalizarAdocao(connection, chip);
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nAdoção Realizada com Sucesso!!!");
                Pausa();
                connection.Close();
            }
            catch
            {
                Console.WriteLine("\n\nDesculpe, Não foi possível realizar essa Adoção. Tente novamente.\n" +
                                  "Certifique-se de que o 'CPF' e o 'CHIP' informados sejam digitados corretamente.");
                Pausa();
                connection.Close();
                Tela_Adocao(connection);
            }
        }
        static void FinalizarAdocao(SqlConnection connection, int chip) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Animal SET Situacao = 'ADOTADO' WHERE CHIP = @CHIP;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLchip = new SqlParameter("@CHIP", System.Data.SqlDbType.Int);

            SQLchip.Value = chip;

            cmd.Parameters.Add(SQLchip);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        static void DesfazerUmaAdocao(SqlConnection connection) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "DELETE FROM Adota WHERE CHIP = @CHIP;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLchip = new SqlParameter("@CHIP", System.Data.SqlDbType.Int);

            Console.WriteLine("DESFAZER UMA ADOÇÃO\n\n");

            Console.Write("Informe o 'CHIP' do Pet que deseja desvincular uma Adoção: ");
            int chip = LerNumero();
            SQLchip.Value = chip;

            cmd.Parameters.Add(SQLchip);

            cmd.Prepare();

            try
            {
                connection.Close();
                FinalizarDesfazerAdocao(connection, chip);
                connection.Open();
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("\nDesvínculo de Adoção Realizado com Sucesso!!!");
                Pausa();
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Desculpe, Houve um erro inesperado...\n\nDescrição do Erro: <<<( " + ex + " )>>>");
                Pausa();
                connection.Close();
                Tela_Adocao(connection);
            }
        }
        static void FinalizarDesfazerAdocao(SqlConnection connection, int chip) // OK
        {
            Console.Clear();
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "UPDATE Animal SET Situacao = 'DISPONIVEL' WHERE CHIP = @CHIP;";
            cmd.Connection = connection;
            connection.Open();

            SqlParameter SQLchip = new SqlParameter("@CHIP", System.Data.SqlDbType.Int);

            SQLchip.Value = chip;

            cmd.Parameters.Add(SQLchip);

            cmd.Prepare();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        static void MostrarAdotantesESeusPets(SqlConnection connection) // OK
        {
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "SELECT Pessoa.CPF, Pessoa.Nome, Animal.Familia, Animal.Nome, Animal.Raca, Animal.Situacao " +
              "FROM Adota " +

              "RIGHT JOIN Pessoa " +

              "ON(Pessoa.CPF = Adota.CPF) " +

              "RIGHT JOIN Animal " +

              "ON(Animal.CHIP = Adota.CHIP) " +

              "WHERE Animal.Situacao = 'ADOTADO';";

            cmd.Connection = connection;
            connection.Open();

            cmd.Prepare();

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    Console.Clear();
                    Console.WriteLine("\nLista de Adotantes e seus Respectivos Pets Adotados:");
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                    Console.WriteLine("|  CPF  |   Nome   |   Animal   |    Nome do Pet   |   Raça  |   Status     |");
                    Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                    while (reader.Read())
                    {
                        Console.WriteLine("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________");
                        Console.Write("{0}",  /*cpf*/reader.GetString(0) + "    |    " +
                                             /*nome*/reader.GetString(1) + "    |    " +
                                           /*animal*/reader.GetString(2) + "    |    " +
                                      /*nome do pet*/reader.GetString(3) + "    |    " +
                                             /*raça*/reader.GetString(4) + "    |    " +
                                           /*Status*/reader.GetString(5) + "    |    \n");
                        Console.Write("________________________________________________________________________________________________________________________________________________________________________________________________________________________________________\n\n");
                    }
                    Console.WriteLine("Fim da Lista");
                    Pausa();
                    connection.Close();
                    Tela_Adocao(connection);
                }
            }
            catch
            {
                Console.WriteLine("\nA Lista está vazia!");
                Pausa();
                connection.Close();
                Tela_Adocao(connection);
            }
        }
        #endregion

        #region FUNCTIONS - GERAL
        static void Pausa() // OK
        {
            Console.WriteLine("Aperte [- ENTER -] para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
        static DateTime LerData() // OK
        {
            do
            {
                try
                {
                    DateTime data = DateTime.Parse(Console.ReadLine());
                    return data;
                }
                catch
                {
                    Console.WriteLine("Data Inválida!");
                }
            } while (true);
        }
        static int LerNumero() // OK
        {
            do
            {
                try
                {
                    int numero = int.Parse(Console.ReadLine());
                    return numero;
                }
                catch
                {
                    Console.WriteLine("Número inválido!");
                }
            } while (true);
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
