using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GftImoveis.Models
{
    public class Imovel
    {
        [Key]
        public int ImovelId { get; set; }
        
        [Required(ErrorMessage="Necessário escrever uma descrição")]
        public string Descrição { get; set; }

        [Required(ErrorMessage="Necessário escolher uma categoria")]
        [Display(Name="Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage="Necessário escolher um município")]
        [Display(Name="Município")]
        public int MunicipioID { get; set; }

        [Required(ErrorMessage="Necessário escolher um bairro")]
        [Display(Name="Bairro")]
        public int BairroId { get; set; }

        [Required(ErrorMessage="Necessário escolher um estado")]
        [Display(Name="Estado")]
        public int EnderecoId { get; set; }

        [Required(ErrorMessage="Necessário escolher uma quantidade")]
        [Display(Name="Quartos")]
        public int QuartoId { get; set; }

        [Required(ErrorMessage="Necessário escolher um negócio")]
        [Display(Name="Negócios")]
        public int NegocioId { get; set; }

        [Display(Name="Categoria")]
        public virtual Categoria CategoriaIm { get; set; }

        [Display(Name="Municícpio")]
        public virtual Municipio MunicipioIm { get; set; }

        [Display(Name="Bairro")]
        public virtual Bairro BairroIm { get; set; }

        [Display(Name="Estado")]
        public virtual Endereco EnderecoIm { get; set; }

        
        [Display(Name="Quartos")]
        public virtual Quarto QuantosIm { get; set; }
        

        [Display(Name="Negócios")]
        public virtual Negocio NegocioIm { get; set; }

        // Será usado como atributo de imagem
        public string Imagem { get; set; }
        
        [NotMapped]    // Não será mapeado para o banco de dados, será utilizado em conjunto com o atributo imagem.
        [Display(Name="Imagem")]
        public IFormFile NovaImagem { get; set; }
         
        [Required]
        [DataType(DataType.Currency)]
        [Display(Name="Preço")]
        public decimal Preco { get; set; }

    }
}