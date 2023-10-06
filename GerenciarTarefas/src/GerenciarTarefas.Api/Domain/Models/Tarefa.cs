using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciarTarefas.Api.Domain.Models
{
    public class Tarefa
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long IdUsuario { get; set; }

        public Usuario? Usuario { get; set; }

        [Required(ErrorMessage = "Título obrigatório")]
        public string Titulo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status obrigatório")]
        public string StatusTarefa { get; set; } = string.Empty;
    }
}