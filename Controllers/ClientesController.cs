// Importa namespaces e bibliotecas necessárias para MVC
// Entity Framework Core e modelos de dados
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MeuCadastroClientesMvc.Data;
using MeuCadastroClientesMvc.Models;
using System.Linq;
using System.Threading.Tasks;

// Define o namespace para os controladores da aplicação

namespace MeuCadastroClientesMvc.Controllers
{

    // Define a classe ClientesController que herda de Controller
    public class ClientesController : Controller
    {

        // Campo privado para armazenar o contexto do banco de dados
        private readonly ApplicationDbContext _context;

        // Construtor que inicializa o contexto do banco de dados

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // Ação ou tarefa para listar todos os clientes
        public async Task<IActionResult> Index()
        {

             // Retorna a view com a lista de clientes obtida de forma assíncrona
            return View(await _context.Cliente.ToListAsync());
        }

         // Ação ou tarefa para exibir detalhes de um cliente específico
        public async Task<IActionResult> Details(int? id)
        {

            // Verifica se o ID é nulo
            if (id == null)
            {
                return NotFound();
            }
             
             // Obtém o cliente com o ID especificado de forma assíncrona
            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ID_Cliente == id);

            // Verifica se o cliente foi encontrado
            if (cliente == null)
            {
                return NotFound();
            }

        // Retorna a view com os detalhes do cliente
            return View(cliente);
        }

        // Ação para exibir o formulário de criação
        // de um novo cliente
        public IActionResult Create()
        {
            return View();
        }

       // Ação POST para criar um novo cliente
   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {

            // Verifica se o modelo é válido
            if (ModelState.IsValid)
            {
                // Adiciona o novo cliente ao contexto
                _context.Add(cliente);

                // Salva as alterações de forma assíncrona
                await _context.SaveChangesAsync();

                // Redireciona para a ação Index
                return RedirectToAction(nameof(Index));
            }

            // Retorna a view com o cliente caso o modelo seja inválido
            return View(cliente);
        }
       
       // Ação ou tarefa para exibir o formulário de edição
       // de um cliente existente
        public async Task<IActionResult> Edit(int? id)
        {
            // Verifica se o ID é nulo
            if (id == null)
            {
                return NotFound();
            }

            // Obtém o cliente com o ID especificado
            // de forma assíncrona
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            // Retorna a view com o cliente para edição
            return View(cliente);
        }

        // Ação POST para editar um cliente existent
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cliente cliente)
        {
            // Verifica se o ID do cliente
            // corresponde ao ID fornecido
            if (id != cliente.ID_Cliente)
            {
                return NotFound();
            }

            // Verifica se o modelo é válido

            if (ModelState.IsValid)
            {
                try
                {
                    // Atualiza o cliente no contexto
                    _context.Update(cliente);

                    // Salva as alterações de forma assíncrona
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Verifica se o cliente ainda existe
                    // no banco de dados
                    if (!ClienteExists(cliente.ID_Cliente))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                // Redireciona para a ação Index
                return RedirectToAction(nameof(Index));
            }

            // Retorna a view com o cliente
            // caso o modelo seja inválido
            return View(cliente);
        }

        // Ação para exibir o formulário de exclusão
        // de um cliente

        public async Task<IActionResult> Delete(int? id)
        {
            // Verifica se o ID é nulo
            if (id == null)
            {
                return NotFound();
            }
    
            // Obtém o cliente com o ID especificado 
            //de forma assíncrona
            var cliente = await _context.Cliente.FirstOrDefaultAsync(m => m.ID_Cliente == id);

            // Verifica se o cliente foi encontrado
            if (cliente == null)
            {
                return NotFound();
            }

            // Retorna a view com o cliente
            // para confirmação de exclusão

            return View(cliente);
        }

        // Ação POST para confirmar a exclusão de um cliente

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            // Obtém o cliente com o ID especificado
            // de forma assíncrona
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                // Remove o cliente do contexto
                _context.Cliente.Remove(cliente);

                // Salva as alterações de forma assíncrona
                await _context.SaveChangesAsync();

                // Adiciona uma mensagem temporária de sucesso
                TempData["Message"] = "Cliente excluído com sucesso.";
            }

            // Redireciona para a ação Index
            return RedirectToAction(nameof(Index));
        }

        // Método privado para verificar se um cliente
        // existe no banco de dados

        private bool ClienteExists(int id)
        {

        // Retorna true se o cliente com o ID especificado existir
        // caso contrário Retorna false
            return _context.Cliente.Any(e => e.ID_Cliente == id);
        }
    }
}





