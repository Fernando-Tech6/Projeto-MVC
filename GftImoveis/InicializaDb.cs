using System.Linq;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GftImoveis
{
    public class InicializaDb
    {
       //  private readonly UserManager<IdentityUser> _userManager;
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.Migrate();  

            if (context.Enderecos.Any())
            { //Se tiver algum item ele returna nulo
                return;
            }
            
            /* Será criado um array de objetos com valores e um laço foreach para adicionar cada objeto.
              Para passar objetos que possuem relacionamentos é necessário informar o array com o objeto correto.
            */

            /*Categoria*/
            var cat = new Categoria[]
            {
                new Categoria{Nome = "Casa"},
                new Categoria{Nome = "Apartamento"},
                new Categoria{Nome = "Sitio"}
            };


            foreach (var item in cat)
            {
                context.Categorias.Add(item);
            }
            
            /*Quarto*/
            var quarto = new Quarto[]
            {
                new Quarto{Quantidade = 1},
                new Quarto{Quantidade = 2},
                new Quarto{Quantidade = 3},
                new Quarto{Quantidade = 4}

            };

            foreach(var item in quarto)
            {
                context.Quartos.Add(item);
            }
            
            /*Estado*/
            var endereco = new Endereco[]
            {
                new Endereco {Nome = "São Paulo", UF = "SP"},
                new Endereco {Nome = "Rio de Janeiro", UF = "RJ"},
                new Endereco {Nome = "Paraná", UF = "PR"},
                new Endereco {Nome = "Pernambuco", UF = "PE"}


            };

             foreach(var item in endereco)
            {
                context.Enderecos.Add(item);
            }
            
            /*Municipio*/
            var munc = new Municipio[]
            {
                new Municipio {Nome = "Sorocaba", EnderecoM = endereco[0]},
                new Municipio {Nome = "Duque de Caxias", EnderecoM = endereco[1]},
                new Municipio {Nome = "Curitiba", EnderecoM = endereco[2]},
                new Municipio {Nome = "Porto de Galinhas", EnderecoM = endereco[3]}


            };

             foreach(var item in munc)
            {
                context.Municipios.Add(item);
            }

            /*Bairro*/
            var barr = new Bairro[]
            {
                new Bairro {Nome = "Jardim Simus", MunicipioB = munc[0]},
                new Bairro {Nome = "Beira Mar", MunicipioB = munc[1]},
                new Bairro {Nome = "Jardim Botânico", MunicipioB = munc[2]},
                new Bairro {Nome = "Muro Alto", MunicipioB = munc[3]},


            };

            foreach (var item in barr)
            {
                context.Bairros.Add(item);
            }

            /*Negocios*/
            var negocios = new Negocio[]
            {
                new Negocio {Nome = "Aluguel"},
                new Negocio {Nome = "Compra"},
                new Negocio {Nome = "Negocia"}
            };

            foreach (var item in negocios)
            {
                context.Negocios.Add(item);
            }
            
            /*Imovel*/
            var imovel = new Imovel[]
            {  
              new Imovel{Descrição = "Otimo Lugar", CategoriaIm= cat[0], MunicipioIm = munc[0], BairroIm = barr[0], EnderecoIm = endereco[0], QuantosIm = quarto[0], NegocioIm = negocios[0], Imagem = "casa1.jpg", Preco = 2000m},
              new Imovel{Descrição = "Grande Oportunidade", CategoriaIm= cat[1], MunicipioIm = munc[1], BairroIm = barr[1], EnderecoIm = endereco[1], QuantosIm = quarto[1], NegocioIm = negocios[1], Imagem = "casa2.jpg", Preco = 450000m},
              new Imovel{Descrição = "Melhor oportunidade", CategoriaIm= cat[2], MunicipioIm = munc[2], BairroIm = barr[2], EnderecoIm = endereco[2], QuantosIm = quarto[2], NegocioIm = negocios[2], Imagem = "casa3.jpg", Preco = 380000m}, 
              new Imovel{Descrição = "Inauguração", CategoriaIm= cat[0], MunicipioIm = munc[3], BairroIm = barr[3], EnderecoIm = endereco[3], QuantosIm = quarto[3], NegocioIm = negocios[0], Imagem = "extra5.jpg", Preco = 7500m}, 
              new Imovel{Descrição = "Imperdível", CategoriaIm= cat[1], MunicipioIm = munc[2], BairroIm = barr[2], EnderecoIm = endereco[2], QuantosIm = quarto[2], NegocioIm = negocios[1], Imagem = "extra1.jpg", Preco = 435000m}, 
              new Imovel{Descrição = "Corra Logo", CategoriaIm= cat[0], MunicipioIm = munc[0], BairroIm = barr[0], EnderecoIm = endereco[0], QuantosIm = quarto[3], NegocioIm = negocios[1], Imagem = "extra2.jpg", Preco = 590000m} 

            };

            foreach(var item in imovel)
            {
                context.Imoveis.Add(item);
            }

            /*Usuario*/

            var usuario = new IdentityUser[]
            { // o id e o password foi conseguido realizado um cadastro no banco de dados e copiado os dados.
                new IdentityUser
                {
                    Id = "3d937da3-8c28-4f32-ac2b-e106e62f754f", UserName = "adm@admin.com",
                    NormalizedUserName = "ADM@ADMIN.COM", Email = "adm@admin.com",  NormalizedEmail = "ADM@ADMIN.COM",
                    EmailConfirmed = false, PasswordHash = "AQAAAAEAACcQAAAAEKaXB+x4qUe2V4DW2MIJc+9PMfCqlw9d+FpN8+lCpmDFnWMEAaEc7SoJZUrlNC2pnQ==",
                    SecurityStamp = "BS4LF6DETQETTREE5RJQB7457VLVK4NM", ConcurrencyStamp = "7ab0e77c-d3ce-42eb-bca3-dbd5a0b3263f",
                    PhoneNumberConfirmed = false, TwoFactorEnabled = false, LockoutEnabled = true, AccessFailedCount = 0

                }
            };

            foreach(var item in usuario)
            {
                context.Users.Add(item);
            }

            /* Claims */

            var claim = new IdentityUserClaim<string>[]
            {     // User id é o mesmo id do usuario.
                new IdentityUserClaim<string> {
                 Id = 1, UserId = "3d937da3-8c28-4f32-ac2b-e106e62f754f", ClaimType = "Nome", ClaimValue = "Fernando GFT"
                 
             },

               new IdentityUserClaim<string> {
                 Id = 2, UserId = "3d937da3-8c28-4f32-ac2b-e106e62f754f", ClaimType = "Chave", ClaimValue = "00010"
                 
             }
            };

           foreach(var item in claim)
            {
                context.UserClaims.Add(item);
            }


            context.SaveChanges();

        }
    }
}