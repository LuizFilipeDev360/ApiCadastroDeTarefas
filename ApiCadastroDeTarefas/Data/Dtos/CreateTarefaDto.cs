using System.ComponentModel.DataAnnotations;

namespace ApiCadastroDeTarefas.Data.Dtos;

public class CreateTarefaDto
{

    [Required(ErrorMessage = "O título da tarefa é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }

}
