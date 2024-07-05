// Definição do namespace que agrupa os modelos do aplicativo
namespace MeuCadastroClientesMvc.Models
{
    // Definição da classe ErrorViewModel
    // usada para representar informações sobre erros na aplicação
    public class ErrorViewModel
    {
        // Propriedade pública que armazena o ID da requisição
        public string RequestId { get; set; }

        // Propriedade que verifica se o RequestId não é nulo ou vazio
        // e Retorna true se RequestId tiver um valor
        // caso contrário retorna false

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}

