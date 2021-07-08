using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Data;
using GftImoveis.Models;
using Microsoft.AspNetCore.Authorization;
using GftImoveis.Repositories;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace GftImoveis.Controllers
{
    [Authorize]  // O Usuario normal tem acesso ao controle e a apenas ao Index. Usuario não logado não tem acesso a nada
    public class ImoveisController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IImovelRepository _imovelRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;   // Para uso e manipulação de diretorios

        public ImoveisController(ApplicationDbContext context, IImovelRepository imovelRepository, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _imovelRepository = imovelRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Imoveis
        public async Task<IActionResult> Index(string busca)
        {   //Não irei utiliza o repository no index devido a complexidade da busca.

            var applicationDbContext = _context.Imoveis.Include(i => i.BairroIm)
            .Include(i => i.CategoriaIm).Include(i => i.EnderecoIm)
            .Include(i => i.MunicipioIm).Include(i => i.NegocioIm).Include(i => i.QuantosIm);

            var consulta = from t in _context.Imoveis
                       select t;           // Realizando um select e passando para uma variavel

            consulta = _context.Imoveis.Include(i => i.BairroIm)  // Tenho que incluir se não ele não retorna os valores.
            .Include(i => i.CategoriaIm).Include(i => i.EnderecoIm)
            .Include(i => i.MunicipioIm).Include(i => i.NegocioIm)
            .Include(i => i.QuantosIm);

            if (!String.IsNullOrEmpty(busca))
            {
                consulta = consulta.Where(p => p.EnderecoIm.Nome.Contains(busca) || 
                p.BairroIm.Nome.Contains(busca) || p.NegocioIm.Nome.Contains(busca) ||
                p.MunicipioIm.Nome.Contains(busca) || p.CategoriaIm.Nome.Contains(busca)
                ); 
            }

            return View(await consulta.ToListAsync());
        }


        // GET: Imoveis/Details/5
         [Authorize(Policy = "Adm")]   // Todas as views de manipulação só podem ser manipuladas por administradores
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _imovelRepository.GetAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // GET: Imoveis/Create
         [Authorize(Policy = "Adm")]
        public IActionResult Create()
        {
            ViewData["BairroId"] = new SelectList(_context.Bairros, "BairroId", "Nome");
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome");
            ViewData["MunicipioID"] = new SelectList(_context.Municipios, "MunicipioId", "Nome");
            ViewData["NegocioId"] = new SelectList(_context.Negocios, "NegocioId", "Nome");
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "QuartoId", "Quantidade");

            return View();
        }

        // POST: Imoveis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Adm")]
        public async Task<IActionResult> Create([Bind("ImovelId,Descrição,CategoriaId,MunicipioID,BairroId,EnderecoId,QuartoId,NegocioId,Preco,NovaImagem")] Imovel imovel)
        {
            if (ModelState.IsValid)
            {
                 // Será criado o caminho para salvar a imagem em wwwroot e obter essa imagem para uso em cada objeto.
                var album = _webHostEnvironment.WebRootPath;
                string arquivo = Path.GetFileNameWithoutExtension(imovel.NovaImagem.FileName);
                var extensao = Path.GetExtension(imovel.NovaImagem.FileName);
                imovel.Imagem = arquivo = arquivo + DateTime.Now.ToString("yymmssfff") + extensao;

                var path = Path.Combine(album + "/imagem/", arquivo);

                using(var fileStream = new FileStream(path, FileMode.Create))
                {
                    await imovel.NovaImagem.CopyToAsync(fileStream);
                }


                await _imovelRepository.CreateAsync(imovel);
                return RedirectToAction(nameof(Index));
            }

            ViewData["BairroId"] = new SelectList(_context.Bairros, "BairroId", "Nome", imovel.BairroId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", imovel.CategoriaId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", imovel.EnderecoId);
            ViewData["MunicipioID"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", imovel.MunicipioID);
            ViewData["NegocioId"] = new SelectList(_context.Negocios, "NegocioId", "Nome", imovel.NegocioId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "QuartoId", "Quantidade", imovel.QuartoId);

            return View(imovel);
        }

        // GET: Imoveis/Edit/5
         [Authorize(Policy = "Adm")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _imovelRepository.SearchAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }
            ViewData["BairroId"] = new SelectList(_context.Bairros, "BairroId", "Nome", imovel.BairroId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", imovel.CategoriaId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", imovel.EnderecoId);
            ViewData["MunicipioID"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", imovel.MunicipioID);
            ViewData["NegocioId"] = new SelectList(_context.Negocios, "NegocioId", "Nome", imovel.NegocioId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "QuartoId", "Quantidade", imovel.QuartoId);

            return View(imovel);
        }

        // POST: Imoveis/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Adm")]
        public async Task<IActionResult> Edit(int id, [Bind("ImovelId,Descrição,CategoriaId,MunicipioID,BairroId,EnderecoId,QuartoId,NegocioId,Preco,Imagem")] Imovel imovel)
        {
            if (id != imovel.ImovelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _imovelRepository.UpdateAsync(imovel);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImovelExists(imovel.ImovelId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["BairroId"] = new SelectList(_context.Bairros, "BairroId", "Nome", imovel.BairroId);
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", imovel.CategoriaId);
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", imovel.EnderecoId);
            ViewData["MunicipioID"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", imovel.MunicipioID);
            ViewData["NegocioId"] = new SelectList(_context.Negocios, "NegocioId", "Nome", imovel.NegocioId);
            ViewData["QuartoId"] = new SelectList(_context.Quartos, "QuartoId", "Quantidade", imovel.QuartoId);

            return View(imovel);
        }

        // GET: Imoveis/Delete/5
        [Authorize(Policy = "Adm")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var imovel = await _imovelRepository.GetAsync(id);

            if (imovel == null)
            {
                return NotFound();
            }

            return View(imovel);
        }

        // POST: Imoveis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "Adm")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {     
              
                

                 var imovel = await _imovelRepository.SearchAsync(id);
                 await _imovelRepository.DeleteAsync(imovel);

        
            return RedirectToAction(nameof(Index));
        }

        private bool ImovelExists(int id)
        {
            return _imovelRepository.Exists(id);
        }

        public async Task<IActionResult> Contrato(int? id)
        {
             var imovel = await _imovelRepository.GetAsync(id);
            return View(imovel);
        }


    }
}
