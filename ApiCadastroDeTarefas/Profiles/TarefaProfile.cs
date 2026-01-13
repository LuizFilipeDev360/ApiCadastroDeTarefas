using ApiCadastroDeTarefas.Data.Dtos;
using ApiCadastroDeTarefas.Models;
using AutoMapper;

namespace ApiCadastroDeTarefas.Profiles;

public class TarefaProfile : Profile
{
    public TarefaProfile()
    {
        CreateMap<CreateTarefaDto, Tarefa>();
        CreateMap<Tarefa, ReadTarefaDto>();
        CreateMap<UpdateTarefaDto, Tarefa>();
    }
}
