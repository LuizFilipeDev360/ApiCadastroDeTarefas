using ApiCadastroDeTarefas.Data;
using ApiCadastroDeTarefas.Models;

namespace ApiCadastroDeTarefas.Repository;

public class TarefaRepository
{
    private TarefasContext _context;

    public TarefaRepository(TarefasContext context)
    {
        _context = context;
    }

    public void Add(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
    }

    public IEnumerable<Tarefa> Recupera()
    {
        return _context.Tarefas;
    }

    public IEnumerable<Tarefa> RecuperaPorConclusao(bool concluida)
    {
        return _context.Tarefas.Where(tarefa => tarefa.Concluida == concluida);
    }

    public Tarefa? RecuperaPorTitulo(string titulo)
    {
        return _context.Tarefas.FirstOrDefault(tarefa => tarefa.Titulo == titulo);    
    }

    public Tarefa? RecuperaPorId(int id)
    {
        return _context.Tarefas.FirstOrDefault(t => t.Id == id);
    }

    public void Atualizar(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
    }

    public void Remove(Tarefa tarefa)
    {
        _context.Tarefas.Remove(tarefa);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
