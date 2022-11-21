using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlClient;

namespace locadora_aed
{
    internal class banco
    {
        private static SQLiteConnection conn;

        private static SQLiteConnection conexaoBanco()
        {
            // Cria a conexão com o banco de dados
            conn = new SQLiteConnection("Data Source=C:\\Users\\victo\\OneDrive\\Área de Trabalho\\locadora-aed\\banco\\bd-locadora.db");
            conn.Open();  // Abre a conexão com o banco
            return conn;  // Retorna a conexão
        }

        // Método para fazer select de usuarios no banco de dados, criando uma tabela própia do VS
        public static DataTable chamaUsers() // Método que obtem usuarios do sistema
        {
            SQLiteDataAdapter data = null;   // Cria um adaptador de dados vazio
            DataTable dataTable = new DataTable(); // Cria uma tabela de dados vazia do VS
            try
            {
                using (var comand = conexaoBanco().CreateCommand())  // Cria um comando para fazer o select no banco de dados
                {
                    comand.CommandText = "SELECT * FROM tb_usuarios";  // Comando que será usado passado para uma variável "comand"
                    data = new SQLiteDataAdapter(comand.CommandText, conexaoBanco());  // Executa o comando no BD e transforma a resposta adaptada
                    data.Fill(dataTable); // Preenche os dados de resposta na tabela do VS
                    conexaoBanco().Close(); // Fecha conexão com o banco pra não ficar ativo.
                    return dataTable; // Retorna todos os usuários cadastrados no sistemas.
                }
            }
            catch(Exception ex)
            {
                conexaoBanco().Close(); // Fecha conexão com o banco pra não ficar ativo.
                throw ex;
            }

        }

        public static DataTable consultaBanco(string sql) // Método genérico para busca no banco de dados
        {
            SQLiteDataAdapter data = null;   // Cria um adaptador de dados vazio
            DataTable dataTable = new DataTable(); // Cria uma tabela de dados vazia do VS
            try
            {
                using (var comand = conexaoBanco().CreateCommand())  // Cria um comando para fazer o select no banco de dados
                {
                    comand.CommandText = sql;  // Comando que será usado passado para uma variável "comand"
                    data = new SQLiteDataAdapter(comand.CommandText, conexaoBanco());  // Executa o comando no BD e transforma a resposta adaptada
                    data.Fill(dataTable); // Preenche os dados de resposta na tabela do VS
                    conexaoBanco().Close(); // Fecha conexão com o banco pra não ficar ativo.
                    return dataTable; // Retorna todos os usuários cadastrados no sistemas.
                }
            }
            catch (Exception ex)
            {
                conexaoBanco().Close(); // Fecha conexão com o banco pra não ficar ativo.
                throw ex;
            }
        }
    }
}
