using ApiElevadorGramado.Models;
using Microsoft.EntityFrameworkCore;

public class AvisosContext : Microsoft.EntityFrameworkCore.DbContext
{

    public Microsoft.EntityFrameworkCore.DbSet<Aviso> Avisos { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=avisos.db");
    }


    public AvisosContext(DbContextOptions<AvisosContext> options) : base(options)
    {
    }

}
