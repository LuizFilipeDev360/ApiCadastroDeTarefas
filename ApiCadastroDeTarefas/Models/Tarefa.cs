using System.ComponentModel.DataAnnotations;

namespace ApiCadastroDeTarefas.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O título da tarefa é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public bool Concluida { get; set; } = false;
    }
}
