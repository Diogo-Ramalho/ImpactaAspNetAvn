using System.ComponentModel.DataAnnotations;

namespace Empresa.Dominio
{
    public class Contato
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public string Assunto { get; set; }
        public string Mensagem { get; set; }


    }
}
