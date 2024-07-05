// Importa o namespace onde está definida a classe ApplicationDbContext
using MeuCadastroClientesMvc.Data;
// Importa o namespace para usar Entity Framework Core
using Microsoft.EntityFrameworkCore;

// Cria um construtor para configurar o aplicativo web

var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao contêiner de injeção de dependência

builder.Services.AddDbContext<ApplicationDbContext>(options => // Adiciona o contexto do banco de dados ao contêiner
    options.UseMySql(
        // Obtém a string de conexão do arquivo de configuração
        builder.Configuration.GetConnectionString("DefaultConnection"),
        // Especifica a versão do servidor MySQL
        new MySqlServerVersion(new Version(8, 0, 21))
    )
);
// Adiciona suporte aos controladores MVC com as views
builder.Services.AddControllersWithViews();

// Constrói a aplicação
var app = builder.Build();

// Configura o pipeline de requisição HTTP
// e Verifica se o ambiente não é de desenvolvimento
if (!app.Environment.IsDevelopment())
{
// Configura o tratamento de exceções para redirecionar
// para a página de erro
    app.UseExceptionHandler("/Home/Error");
    // Adiciona suporte a HSTS (HTTP Strict Transport Security)
    app.UseHsts();
}
// Redireciona requisições HTTP para HTTPS
app.UseHttpsRedirection();
// Habilita o uso de arquivos estáticos
app.UseStaticFiles();
// Habilita o roteamento de requisições
app.UseRouting();
// Habilita a autorização
app.UseAuthorization();
// Mapeia uma rota padrão para os controladores
app.MapControllerRoute(
    name: "default",
    // Define a rota padrão: controlador = Clientes,
    // ação = Index, id é opcional
    pattern: "{controller=Clientes}/{action=Index}/{id?}"
);

// Executa a aplicação
app.Run();




