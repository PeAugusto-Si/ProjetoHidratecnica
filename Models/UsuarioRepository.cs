using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace Projeto_Hidratecnica.Models
{
    public class UsuarioRepository
    {   
        /*ENDEREÇO DE CONEXÃO*/
        private const  string enderecoConexao = "Database=hidratecnica; Datasource=localhost; User Id=root;";

    
  
     
    /*CADASTRO DE MENSAGENS*/
    public void Insert_Mensagens(Mensagens mensagem){
                  
    MySqlConnection conexao = new MySqlConnection(enderecoConexao);

    conexao.Open();

    string sqlInsert = "INSERT INTO mensagens (nome, email, assunto, mensagem, data) VALUES (@nome, @email, @assunto, @mensagem, @data)";

    MySqlCommand comando = new MySqlCommand(sqlInsert, conexao);

    comando.Parameters.AddWithValue("@nome", mensagem.nome);
    comando.Parameters.AddWithValue("@email", mensagem.email);
    comando.Parameters.AddWithValue("@assunto", mensagem.assunto);
    comando.Parameters.AddWithValue("@mensagem", mensagem.mensagem);
    comando.Parameters.AddWithValue("@data", mensagem.data);
    

    comando.ExecuteNonQuery();

    conexao.Close();
    
    }

    /*LISTAGEM DE MENSAGENS*/
    public List<Mensagens> Listar_Mensagens(){

        MySqlConnection conexao = new MySqlConnection(enderecoConexao);

        conexao.Open();

        string sqlList = "SELECT * FROM mensagens ORDER BY nome";

        MySqlCommand comando = new MySqlCommand(sqlList, conexao);

        MySqlDataReader dados = comando.ExecuteReader();

        List<Mensagens> lista = new List<Mensagens>();
        
        while(dados.Read()){
        
        Mensagens mensagem = new Mensagens();

        mensagem.id = dados.GetInt32("id_mensagens");

        if(!dados.IsDBNull(dados.GetOrdinal("nome")))
        mensagem.nome = dados.GetString("nome");

        if(!dados.IsDBNull(dados.GetOrdinal("email")))
        mensagem.email = dados.GetString("email");

        if(!dados.IsDBNull(dados.GetOrdinal("assunto")))
        mensagem.assunto = dados.GetString("assunto");

        if(!dados.IsDBNull(dados.GetOrdinal("mensagem")))
        mensagem.mensagem = dados.GetString("mensagem");

        if(!dados.IsDBNull(dados.GetOrdinal("data")))
        mensagem.data = dados.GetString("data");

        

        lista.Add(mensagem);

        }
        
        conexao.Close();
        return lista;
    }

    /*ALTERAÇÃO DE MENSAGENS*/
     public void Alterar_M(Mensagens m){

    MySqlConnection conexao = new MySqlConnection(enderecoConexao);

    conexao.Open();

    string sqlUpdate = "UPDATE mensagens set nome = @nome, email = @email, assunto = @assunto, mensagem = @mensagem, data = @data WHERE id_mensagens = @id";        
    
    MySqlCommand comando = new MySqlCommand(sqlUpdate, conexao);

    comando.Parameters.AddWithValue("@id", m.id);
    comando.Parameters.AddWithValue("@nome", m.nome);
    comando.Parameters.AddWithValue("@email", m.email);
    comando.Parameters.AddWithValue("@assunto", m.assunto);
    comando.Parameters.AddWithValue("@mensagem", m.mensagem);
    comando.Parameters.AddWithValue("@data", m.data);
    
    
    comando.ExecuteNonQuery();
    
    conexao.Close();       
    }

    /*EXCLUSÃO DE MENSAGEM*/
     public void Excluir_M(int id){

        MySqlConnection conexao = new MySqlConnection(enderecoConexao);

        conexao.Open();

        string sqlDelete = "DELETE FROM mensagens WHERE id_mensagens = @id";

        MySqlCommand comando = new MySqlCommand(sqlDelete, conexao);

        comando.Parameters.AddWithValue("@id", id);

        comando.ExecuteNonQuery();

        conexao.Close();
    }
    
    /*RETORNO DE MENSAGENS*/
    public Mensagens RetornoMensagem(int id){
    
    int id_mensagem = id;
    
    MySqlConnection conexao = new MySqlConnection(enderecoConexao);

    conexao.Open();

    string sqlConsulta = "SELECT * FROM mensagens WHERE id_mensagens = @id";

    MySqlCommand comando = new MySqlCommand(sqlConsulta, conexao);

    comando.Parameters.AddWithValue("@id", id_mensagem);
    
    MySqlDataReader dados = comando.ExecuteReader();

    dados.Read();

    Mensagens mensagem = new Mensagens();

    mensagem.id = dados.GetInt32("id_mensagens");
    
    if(!dados.IsDBNull(dados.GetOrdinal("nome")))
    mensagem.nome = dados.GetString("nome");

    if(!dados.IsDBNull(dados.GetOrdinal("email")))
    mensagem.email = dados.GetString("email");

    if(!dados.IsDBNull(dados.GetOrdinal("assunto")))
    mensagem.assunto = dados.GetString("assunto");

    if(!dados.IsDBNull(dados.GetOrdinal("mensagem")))
    mensagem.mensagem = dados.GetString("mensagem");

    if(!dados.IsDBNull(dados.GetOrdinal("data")))
    mensagem.data = dados.GetString("data");
    

    conexao.Close();
    return mensagem; 
    }


    
 }
}