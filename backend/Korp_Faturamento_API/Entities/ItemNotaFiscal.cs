using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Korp.Faturamento.API.Entities
{
    public class ItemNotaFiscal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo 'ProdutoId' não pode ser vazio.")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "Campo 'Quantidade' não pode ser vazio.")]
        public int Quantidade { get; set; }

        [Required]
        public int NotaFiscalId { get; set; }

        [ForeignKey("NotaFiscalId")]
        public NotaFiscal? NotaFiscal { get; set; }
    }
}