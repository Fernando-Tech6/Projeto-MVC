using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Quarto
    {
        [Key]
        public int QuartoId { get; set; }

        [Required(ErrorMessage="Necessário preencher a quantidade")]
        public int Quantidade { get; set; }
    }
}