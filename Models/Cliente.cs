// Biblioteca que fornece um conjunto de atributos 
// que são usados para definir regras de validação
// e configuralççaoes dos dados
using System.ComponentModel.DataAnnotations;

namespace MeuCadastroClientesMvc.Models
{
    // Declarção da classe Cliente com os seus atributos
    // e métodos getters e setters
    public class Cliente
    {
      // A propriedade [Key] define que o atributo ID_Cliente
      // é a chave primária da tabela  
        [Key]
        public int ID_Cliente { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public string RG { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }
    }
}

