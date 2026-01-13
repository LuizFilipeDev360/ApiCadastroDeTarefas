using ApiCadastroDeTarefas.Data.Dtos;
using ApiCadastroDeTarefas.Models;
using ApiCadastroDeTarefas.Repository;
using AutoMapper;

namespace ApiCadastroDeTarefas.Services;

public class TarefaService
{

    private static List<Tarefa> _tarefas = new List<Tarefa>();
    private static int id = 0;

    private readonly TarefaRepository _repository;
    private readonly IMapper _mapper;

    public TarefaService(TarefaRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public Tarefa AdicionaTarefa(CreateTarefaDto tarefaDto)
    {
        Tarefa tarefa = _mapper.Map<Tarefa>(tarefaDto);
        //tarefa.Concluida = false;
        //tarefa.DataCriacao = DateTime.Now;
        _repository.Add(tarefa);
        _repository.Save();

        return tarefa;
    }

    public IEnumerable<ReadTarefaDto> RecuperaTarefas()
    {
        var tarefas = _repository.Recupera();
        return _mapper.Map<List<ReadTarefaDto>>(tarefas);
    }

    public IEnumerable<ReadTarefaDto> RecuperaTarefasPorConclusao(bool concluida)
    {
        var tarefas = _repository.RecuperaPorConclusao(concluida);

        var resposta = _mapper.Map<List<ReadTarefaDto>>(tarefas);

        return resposta;
    }

    public ReadTarefaDto? RecuperaTarefaPorTitulo(string titulo)
    {
        var tarefa = _repository.RecuperaPorTitulo(titulo);
        return _mapper.Map<ReadTarefaDto>(tarefa);
    }

    public ReadTarefaDto ConcluirTarefa(int id)
    {

        var tarefa = _repository.RecuperaPorId(id);

        if (tarefa == null)
            return _mapper.Map<ReadTarefaDto>(tarefa);

        tarefa.Concluida = true;

        _repository.Atualizar(tarefa);
        _repository.Save();

        return _mapper.Map<ReadTarefaDto>(tarefa);
    }

    public bool AtualizaTarefa(int id, UpdateTarefaDto tarefaDto)
    {
        var tarefa = _repository.RecuperaPorId(id);
        if (tarefa == null)
            return false;
        var tarefaAtualizada = _mapper.Map<Tarefa>(tarefaDto);

        tarefa.Titulo = tarefaAtualizada.Titulo;
        tarefa.Descricao = tarefaAtualizada.Descricao;
        _repository.Atualizar(tarefa);
        _repository.Save();

        return true;
    }

    public Tarefa DeleteTarefa(int id)
    {
        var tarefa = _repository.RecuperaPorId(id);
        
        _repository.Remove(tarefa);
        _repository.Save();

        return tarefa;
    }

}
