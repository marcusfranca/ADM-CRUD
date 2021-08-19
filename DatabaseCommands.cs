using System;
using MySql.Data.MySqlClient; 

namespace C_

{
    public class DatabaseCommands
    {
        
        
        public void setUserDatabase(string user, string password) {
            MySqlConnection myConnection = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");
            string myInsertQuery = "INSERT INTO crud_USER (usuario, senha) Values('"+user+"', '"+password+"')"; 
            MySqlCommand myCommand = new MySqlCommand(myInsertQuery);    
            myCommand.Connection = myConnection;
            
            try {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
            } catch (Exception e) {
                Console.Error.WriteLine("Error: " + e.Message);
            } finally {
                myCommand.Connection.Close();
            }
            
            
           
        } 

        
        public void selectAllUserDatabase() {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataReader dataReader;

            
            conexao = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");
            comando = new MySqlCommand("SELECT id, usuario, senha FROM crud_USER", conexao);
            
            try {
                conexao.Open();
                dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    string id = Convert.ToString(dataReader["id"]);
                    string usuario = Convert.ToString(dataReader["usuario"]);
                    string senha = Convert.ToString(dataReader["senha"]);

                    Console.WriteLine($"Id: {id} | Usuario: {usuario} | Senha: {senha}");
                }
            } catch (Exception e) {
                Console.Error.WriteLine("ERRO: ", e.Message);
            } finally {
                conexao.Clone();
            }
            
                
        }

        public void selectByIdUserDatabase(int idMysql) {
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataReader dataReader;

            conexao = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");
            comando = new MySqlCommand($"SELECT * FROM crud_USER where id = {idMysql}", conexao);

            try {
                conexao.Open();
                dataReader = comando.ExecuteReader();

                while(dataReader.Read()) {
                    string id = Convert.ToString(dataReader["id"]);
                    string usuario = Convert.ToString(dataReader["usuario"]);
                    string senha = Convert.ToString(dataReader["senha"]);

                    Console.WriteLine($"Id: {id} | Usuário: {usuario} | Senha: {senha}");
                }    
            } catch (Exception e) {
                Console.Error.WriteLine("ERRO: ", e.Message);
            } finally {
                conexao.Close();
            }
      
        }

        public void deteleUserDatabase()
        {
            MySqlConnection conexao;
            MySqlCommand comando;

            conexao = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");
            string myInsertQuery = $"DELETE FROM crud_USER";
            comando = new MySqlCommand(myInsertQuery);
            comando.Connection = conexao;
            try {
                conexao.Open();
                comando.ExecuteNonQuery();    
            } catch (Exception e) {
                Console.Error.WriteLine("ERRO: ", e.Message);
            } finally {
                comando.Connection.Close();
            }
            
            
        }
        
        
        public void deleteByIdDatabase(int delete){
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataReader dataReader;
            conexao = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");

            try{
                comando = new MySqlCommand($"Delete FROM crud_USER where id = {delete}", conexao);
                conexao.Open();
                dataReader = comando.ExecuteReader();
            

                while(dataReader.Read()) {
                    string id = Convert.ToString(dataReader["id"]);
                    string usuario = Convert.ToString(dataReader["usuario"]);
                    string senha = Convert.ToString(dataReader["senha"]);

                    Console.WriteLine($"Id: {id} | Usuário: {usuario} | Senha: {senha}");
                }
            
            }catch(Exception e){
                Console.Error.WriteLine("Error: Eh duro programador" + e.Message);
            }
            finally{
                conexao.Close();
                
            }
        }

         public void updateByIdDatabase(int update, string user, string password){
            MySqlConnection conexao;
            MySqlCommand comando;
            MySqlDataReader dataReader;
            conexao = new MySqlConnection("server=localhost;port=3306;database=Projetos;user id=root;pwd=root;sslmode=none;");
            comando = new MySqlCommand($"UPDATE crud_USER SET usuario = '{user}', senha = '{password}' where id = {update}", conexao);
            conexao.Open();
            dataReader = comando.ExecuteReader();
         }
    }
}

