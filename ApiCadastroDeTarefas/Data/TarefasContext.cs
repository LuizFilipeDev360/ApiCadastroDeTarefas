using ApiCadastroDeTarefas.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroDeTarefas.Data;

public class TarefasContext : IdentityDbContext<AuthUser>
{
    public TarefasContext(DbContextOptions<TarefasContext> opts) : base(opts)
    {
        
    }

    public DbSet<Tarefa> Tarefas { get; set; }
}
