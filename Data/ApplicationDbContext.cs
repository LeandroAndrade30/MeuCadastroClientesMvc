// importação da biblioteca Microsoft.EntityFrameworkCore
// que é utilizada para interagir com o banco de dados
using Microsoft.EntityFrameworkCore;
// Importação do namespace onde é definido o modelo Cliente
using MeuCadastroClientesMvc.Models;
// namespace que  permite acessar os dados do aplicativo
// MeuCadastroClientesMvc
namespace MeuCadastroClientesMvc.Data
{
    //Definição da classe ApplicationDbContext que herda de DbContext
    // as características definidas no banco de dados
    public class ApplicationDbContext : DbContext
    {
        // Construtor da classe ApplicationDbContext que recebe opções
        // de configuração e passa para a classe base DbContext
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Propriedade do tipo DbSet<Cliente> que representa 
        //a coleção  de entidade Cliente no banco de dados

        public DbSet<Cliente> Cliente { get; set; } 

        // Método OnModelCreating para configurar o modelo de dados
        // sobrescrevendo o método da classe base DbContext

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Configuração da entidade Cliente para definir
            // a propriedade ID_Cliente como chave primária
            

            modelBuilder.Entity<Cliente>()
                .HasKey(c => c.ID_Cliente);
        }
    }
}

