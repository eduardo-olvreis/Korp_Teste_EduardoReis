using System.ComponentModel.DataAnnotations;

namespace Korp.Estoque.API.DTOs
{
    public class ProdutoCreateDto
    {
        [Required(ErrorMessage = "Campo 'Codigo' não pode ser vazio.")]
        [MaxLength(30)]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Campo 'Descricao' não pode ser vazio.")]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo 'Saldo' não pode ser vazio")]
        public int Saldo { get; set; }
    }
}
