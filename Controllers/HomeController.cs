using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projeto_Hidratecnica.Models;
using Microsoft.AspNetCore.Http;

namespace Projeto_Hidratecnica.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        /****************************************CONTROLLeR INDEX *******************************************/
        
        public IActionResult Index()
        {
            return View();
        }

        /****************************************CONTROLLER SERVIÇOS****************************************/

        public IActionResult Serviços()
        {
            return View();
        }

        /****************************************CONTROLLER INSTITUCIONAL***********************************/

         public IActionResult Institucional()
        {
            return View();
        }
    
        /***********************************CONTROLLERS MENSAGENS*****************************************/

        /*Mensagens*/
        public IActionResult Mensagens()
        {  
                  
            UsuarioRepository ur = new UsuarioRepository();
            List<Mensagens> mensagens = ur.Listar_Mensagens();
            return View(mensagens);
        }
        
        /*ReGISTRO De MENSAGENS*/
        public IActionResult Registro_Mensagens()
        {     
            return View();
        }

        [HttpPost]  
         public IActionResult Registro_Mensagens(Mensagens mensage)
        {   
            UsuarioRepository ur = new UsuarioRepository();

            try{
              ur.Insert_Mensagens(mensage);
               ViewBag.Cadastro = "Mensagem registrada com sucesso!";
            } catch {
              ViewBag.Cadastro = "Falha ao registrar mensagem!";
            }
            
            return View();
        }
        
        /*LISTAGEM De MENSAGENS*/
         public IActionResult Listar_Mensagens(){
          
          UsuarioRepository ur = new UsuarioRepository();
          
          List<Mensagens> listagem = ur.Listar_Mensagens();
          
          return View(listagem);

        }

        /*ALTERAÇÃO De MENSAGENS*/
         [HttpGet]
        public IActionResult Alterar_Mensagem(int id){
            
            UsuarioRepository ur = new UsuarioRepository();
            
            Mensagens m = ur.RetornoMensagem(id);
        
            return View(m);
        }

         [HttpPost]
        public IActionResult Alterar_Mensagem(Mensagens mensage){
         
         UsuarioRepository ur = new UsuarioRepository();
            
            ur.Alterar_M(mensage);
             
            return RedirectToAction("Listar_Mensagens");
        }

        /*EXCLUSÃO De MENSAGENS*/
        [HttpGet]
        public IActionResult Excluir_Mensagens(int id){

            UsuarioRepository ur = new UsuarioRepository();

            ur.Excluir_M(id);
            
            return RedirectToAction("Mensagens");
        }
        
        [HttpGet]
        public IActionResult excluir_Mensagem(int id){

            UsuarioRepository ur = new UsuarioRepository();

            ur.Excluir_M(id);
            
            return RedirectToAction("Listar_Mensagens");
        }

        

       
        

    }
}
