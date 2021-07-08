using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Municipio
    {
        [Key]
        public int MunicipioId { get; set; }

        [Required(ErrorMessage="Necessário preencher esse campo")]
        [Display(Name = "Municípios")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage="Necessário escolher um estado")]
        [Display(Name = "Estados")]
        public int EnderecoId { get; set; }

        [Display(Name = "Estados")]
        public Endereco EnderecoM { get; set; }

        public ICollection<Bairro> BairroM { get; set; }
    }
}