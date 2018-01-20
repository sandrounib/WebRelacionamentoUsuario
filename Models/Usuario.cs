using System;
using System.Collections.Generic;

namespace WebRelacionamento.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public DateTime Datacadastro { get; set; }

        /*
        public List<Usuario> Listar(){
            return new List<Usuario>(){
                new Usuario{Id=10,Nome="Pedro",Login="Pedrounib",Senha="1234",Datacadastro=DateTime.Now},                
                new Usuario{Id=15,Nome="Sandro",Login="sandrounib",Senha="654321",Datacadastro=DateTime.Now},                
            };  */
        
        
    }
}