using System.ComponentModel.DataAnnotations;

namespace ApiCadastroDeTarefas.Data.Dtos;

public class UpdateTarefaDto
{
    [Required(ErrorMessage = "O título do filme é obrigatório")]
    public string Titulo { get; set; }
    [Required(ErrorMessage = "A descrição é obrigatória")]
    public string Descricao { get; set; }
}
