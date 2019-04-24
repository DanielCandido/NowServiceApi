using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Workers.Models
{
    public class Prestador
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nascimento { get; set; }
        public string Senha { get; set; } 

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }        
    }
}