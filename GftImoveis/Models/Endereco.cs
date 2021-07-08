using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Endereco
    {
        [Key]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage="Necessário preencher esse campo")]
        [Display(Name="Estado")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Necessário preencher esse campo")]
        public string UF { get; set; }
        
        public ICollection<Municipio> MunicipioEnd { get; set; }
    }
}