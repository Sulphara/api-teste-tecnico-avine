using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI.Models
{
    public class TaskItem
    {
        [Key] 
        public int Id { get; set; } // Auto-incrementado pelo banco de dados

        [Required(ErrorMessage = "O título é obrigatório.")]
        [MinLength(2, ErrorMessage = "O título deve ter no mínimo 2 caracteres.")]
        [MaxLength(200, ErrorMessage = "O título deve ter no máximo 200 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 5 caracteres.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "A data final é obrigatória.")]
        public DateTime FinishedAt { get; set; }

        public bool IsCompleted { get; set; }
    }
}
