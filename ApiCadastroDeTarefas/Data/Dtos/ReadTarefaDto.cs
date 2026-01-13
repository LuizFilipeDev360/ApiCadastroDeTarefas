namespace ApiCadastroDeTarefas.Data.Dtos;

public class ReadTarefaDto
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataCriacao { get; set; }
    public bool Concluida { get; set; }
}
