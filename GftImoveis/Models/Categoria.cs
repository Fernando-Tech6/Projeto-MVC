using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
         
        [Required(ErrorMessage="Necessário preencher esse campo")]
        [Display(Name="Categoria")]
        public string Nome { get; set; }

    }
}