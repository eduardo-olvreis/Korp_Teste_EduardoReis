using System.ComponentModel.DataAnnotations;

namespace Korp.Faturamento.API.Entities
{
    public class NotaFiscal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'NumeroSequencial' não pode ser vazio.")]
        public int NumeroSequencial { get; set; }

        [Required(ErrorMessage = "Campo 'Status' não pode ser vazio.")]
        [MaxLength(10)]
        public string Status { get; set; } = "Aberta";

        public ICollection<ItemNotaFiscal> Itens { get; set; } = new List<ItemNotaFiscal>();
    }
}