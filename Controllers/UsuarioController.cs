using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebRelacionamento.Models;

namespace WebRelacionamento.Controllers
{
    public class UsuarioController:Controller    
    {
        Usuario usuario = new Usuario();
        DAOUsuario dao = new DAOUsuario();

        /*servia para listar
        [HttpGet]
        [Route("api/[controller]")]
        public IEnumerable<Usuario> GetUsuario(){
            return usuario.Listar();
        }  */     

        [HttpGet]
        [Route("api/listarusuario")]
        public IEnumerable<Usuario> GetUsuario(){
            return dao.Listar();
        }

        [HttpGet("{id}",Name="UsuarioAtual")]
        [Route("api/listarusuario/{id}")]

        public Usuario Get(int id){
            return dao.Listar().Where(x => x.Id == id).FirstOrDefault();            
        }

        [HttpPost]
        [Route("api/cadUsuario")]
        public IActionResult PostCadastrar([FromBody] Usuario usuario){
            dao.CadastrarUsuario(usuario);
            return CreatedAtRoute("UsuarioAtual",new{id=usuario.Id},usuario);            
        }

        [HttpPut]
        public IActionResult Editar([FromBody]Usuario usuario){

            return BadRequest();
        }



    }
}