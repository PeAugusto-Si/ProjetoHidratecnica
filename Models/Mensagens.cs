using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;
namespace Projeto_Hidratecnica.Models
{
    public class Mensagens
    {
      
      public int id {get; set;}
      public string nome {get; set;}
      public string email {get; set;}
      public string assunto {get; set;}
      public string mensagem {get; set;}
      public string data {get; set;}
      public int usuario {get; set;}
        
    }
}