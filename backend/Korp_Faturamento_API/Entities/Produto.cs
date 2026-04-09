using System.ComponentModel.DataAnnotations;

namespace Korp.Estoque.API.Entities
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }

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
