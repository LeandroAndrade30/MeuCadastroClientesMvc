// Importa namespaces e bibliotecas necessárias
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MeuCadastroClientesMvc.Models;


// Define o namespace para os controladores da aplicação
namespace MeuCadastroClientesMvc.Controllers;

// Define a classe HomeController que herda de Controller
public class HomeController : Controller
{
    // Campo privado para armazenar o logger
    private readonly ILogger<HomeController> _logger;

    // Construtor que inicializa o logger
    // através de injeção de dependência
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }


    // Ação para exibir a página inicial
    public IActionResult Index()
    {
    // Retorna a view correspondente à ação Index
        return View();
    }

    // Ação para exibir a página de privacidade
    public IActionResult Privacy()
    {
   // Retorna a view correspondente à ação Privacy
        return View();
    }

    // Ação para exibir a página de erro
    // O atributo ResponseCache desabilita
    // o cache para esta ação

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {

    // Cria um modelo de erro com o ID da requisição atual
    // ou o identificador de rastreamento HTTP
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
