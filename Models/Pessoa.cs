using System.ComponentModel.DataAnnotations;

namespace Agenda.Models
{
    public class Pessoa
    {
        [Display(Name = "Código")]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Logradouro { get; set; }
        [Display(Name = "Núm.")]
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
    }
}
