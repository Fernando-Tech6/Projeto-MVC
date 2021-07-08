using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GftImoveis.Models
{
    public class Negocio
    {
        [Key]
        public int NegocioId { get; set; }

        [Required(ErrorMessage="Necessário escolher um negócio")]
        public string Nome { get; set; }

        public virtual ICollection<Imovel> ImovelN { get; set; } 
    }
}