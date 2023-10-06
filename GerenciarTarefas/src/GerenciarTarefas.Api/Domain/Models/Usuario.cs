using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Domain.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "Nome obrigatório")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email obrigatório")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Senha obrigatório")]
        public string Senha { get; set; } = string.Empty;

    }
}