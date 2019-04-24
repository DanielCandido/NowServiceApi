using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Workers.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
    }
}