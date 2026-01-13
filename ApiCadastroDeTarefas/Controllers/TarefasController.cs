using ApiCadastroDeTarefas.Data.Dtos;
using ApiCadastroDeTarefas.Models;
using ApiCadastroDeTarefas.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiCadastroDeTarefas.Controllers;

[ApiController]
[Route("[controller]")]
public class TarefasController : ControllerBase
{
    TarefaService _service;
    public TarefasController(TarefaService service)
    {
        _service = service;
    }
    /*
     Console.WriteLine("1 - Adicionar Tarefa");
    Console.WriteLine("2 - Listar todas as tarefas");
    Console.WriteLine("3 - Listar tarefas concluidas");
    Console.WriteLine("4 - Listar tarefas pendentes");
    Console.WriteLine("5 - Buscar tarefa por título");
    Console.WriteLine("6 - Concluir tarefa");
    Console.WriteLine("7 - Remover tarefa");
    Console.WriteLine("0 - Sair");
     */

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [Authorize]
    public IActionResult AdicionaTarefa([FromBody] CreateTarefaDto tarefaDto)
    {
        Tarefa tarefa = _service.AdicionaTarefa(tarefaDto);
        return CreatedAtAction(nameof(AdicionaTarefa), new { id = tarefa.Id }, tarefa);
    }

    [HttpGet]
    public IEnumerable<ReadTarefaDto> RecuperaTarefas()
    {
        return _service.RecuperaTarefas();
    }

    [HttpGet("{concluida}")]
    public IActionResult RecuperaFilmePorConclusao(bool concluida)
    {
        var filmes = _service.RecuperaTarefasPorConclusao(concluida);
        return filmes.Any() ? Ok(filmes) : NotFound();
    }

    [HttpGet("titulo/{titulo}")]
    public IActionResult RecuperaTarefaPorTitulo(string titulo)
    {
        var tarefa = _service.RecuperaTarefaPorTitulo(titulo);
        return tarefa != null ? Ok(tarefa) : NotFound();
    }

    [HttpPatch("{id}/concluir")]
    [Authorize]
    public IActionResult ConcluirTarefa(int id)
    {
        var tarefa = _service.ConcluirTarefa(id);
        if (tarefa != null)
        {
            return Ok(tarefa);
        }
        else
        {
            return NotFound();
        }
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult AtualizarTarefa(int id, [FromBody] UpdateTarefaDto tarefaDto)
    {
        var feito = _service.AtualizaTarefa(id, tarefaDto);
        if (feito)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult RemoverTarefa(int id)
    {
        var tarefa = _service.DeleteTarefa(id);
        if (tarefa != null)
        {
            return NoContent();
        }
        else
        {
            return NotFound();
        }
    }
}
