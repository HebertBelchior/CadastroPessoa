using Microsoft.EntityFrameworkCore;

namespace CadastroDePessoa.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) { }
        
        public DbSet<Cadastro> Cadastros { get; set; }
        public DbSet<CadastroTipo> CadastroTipos { get; set; }
        public DbSet<Status> Statuses { get; set; }
    }

}
