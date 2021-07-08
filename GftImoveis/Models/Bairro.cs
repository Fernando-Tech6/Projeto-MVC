using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Bairro
    {
        [Key]
        public int BairroId { get; set; }
        
        [Required(ErrorMessage="Necessário preencher esse campo")]
        [Display(Name = "Bairro")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Necessário preencher esse campo")]
        [Display(Name = "Município")]
        public int MunicipioId { get; set; }
        
        [Display(Name = "Município")]
        public Municipio MunicipioB { get; set; }
    }
}