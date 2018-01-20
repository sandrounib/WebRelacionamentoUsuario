using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace WebRelacionamento.Models
{
    public class DAOUsuario
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader rd = null;
        string conexao = @"Data source=.\SqlExpress;Initial catalog=RelCidades;user id=sa;password=senai@123";

        public List<Usuario> Listar()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                con = new SqlConnection();
                con.ConnectionString = conexao;
                con.Open();
                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from Usuario";
                rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    usuarios.Add(new Usuario()
                    {
                        Id = rd.GetInt32(0),
                        Nome = rd.GetString(1),
                        Login = rd.GetString(2),
                        Senha = rd.GetString(3),
                        Datacadastro = rd.GetDateTime(4)
                    });
                }

            }
            catch (SqlException se)
            {

                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return usuarios;
        }

        public bool CadastrarUsuario(Usuario usuario)
        {
            bool resultado = false;
            try
            {
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Insert into Usuario (nome,login,senha) values(@n,@l,@s)";
             
                cmd.Parameters.AddWithValue("@n", usuario.Nome);
                cmd.Parameters.AddWithValue("@l", usuario.Login);
                cmd.Parameters.AddWithValue("@s", usuario.Senha);
               

                int r = cmd.ExecuteNonQuery();
                if (r > 0)
                    resultado = true;
                cmd.Parameters.Clear();
            }
            catch (SqlException se)
            {
                throw new Exception(se.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
            }
            return resultado;
        }

        public string AtualizarUsuario(Usuario usuario){
            string msg;
            try{
                con = new SqlConnection(conexao);
                cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType= CommandType.Text;
                cmd.CommandText = "Update usuario set nome = @n,login=@l,senha=@s,datacadastro=@d";
                cmd.Parameters.AddWithValue("@n",usuario.Nome);
                cmd.Parameters.AddWithValue("@l",usuario.Login);
                cmd.Parameters.AddWithValue("@s",usuario.Senha);
                cmd.Parameters.AddWithValue("@d",usuario.Datacadastro);
                con.Open();

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Atualização efetuada";
                else    
                    msg = "Não foi possível atualizar";

                cmd.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception("Erro ao tentar atualizar os dados" + se.Message);               
                               
            }
            catch(Exception ex){
                throw new Exception ("Erro inesperadao" + ex.Message);                
            }
            finally{
                con.Close();
            }
            return msg;
        }

        public string ExcluirUsuario(int id){
            string msg;
            try{
                con = new SqlConnection(conexao);
                con.Open();
                cmd = new SqlCommand();

                cmd.Connection = con;

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "delete from usuario where id = @id";
                cmd.Parameters.AddWithValue("@id",id);

                int r = cmd.ExecuteNonQuery();
                if(r > 0)
                    msg = "Delete completado com sucesso";
                else
                    msg = "Não foi possível deletar usuário";
                cmd.Parameters.Clear();
            }
            catch(SqlException se){
                throw new Exception ("Erro ao tentar deletar" + se.Message);               

            }
            catch(Exception ex){
                throw new Exception("Erro inexperado" + ex.Message);
            }
            finally{
                con.Close();
            }
            return msg;
        }



    }
}