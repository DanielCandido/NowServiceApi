using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workers.Models
{
    public class PrestadorDetailDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nascimento { get; set; }
        public string Categoria { get; set; }
    }
}