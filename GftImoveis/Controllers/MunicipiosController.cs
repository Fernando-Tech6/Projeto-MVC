using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Data;
using GftImoveis.Models;
using GftImoveis.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace GftImoveis.Controllers
{
    [Authorize(Policy = "Adm")]
    public class MunicipiosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipiosController(ApplicationDbContext context, IMunicipioRepository municipioRepository)
        {
            _context = context;
            _municipioRepository = municipioRepository;
        }

        // GET: Municipios
        public async Task<IActionResult> Index()
        {
            
            return View(await _municipioRepository.ListaAsync());
        }

        // GET: Municipios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _municipioRepository.GetAsync(id);
            
            if (municipio == null)
            {
                return NotFound();
            }

            return View(municipio);
        }

        // GET: Municipios/Create
        public IActionResult Create()
        {
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome");
            return View();
        }

        // POST: Municipios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MunicipioId,Nome,EnderecoId")] Municipio municipio)
        {
            if (ModelState.IsValid)
            {
                await _municipioRepository.CreateAsync(municipio);
                return RedirectToAction(nameof(Index));
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", municipio.EnderecoId);
            return View(municipio);
        }

        // GET: Municipios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _municipioRepository.SearchAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", municipio.EnderecoId);
            return View(municipio);
        }

        // POST: Municipios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MunicipioId,Nome,EnderecoId")] Municipio municipio)
        {
            if (id != municipio.MunicipioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _municipioRepository.UpdateAsync(municipio);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MunicipioExists(municipio.MunicipioId))
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
            ViewData["EnderecoId"] = new SelectList(_context.Enderecos, "EnderecoId", "Nome", municipio.EnderecoId);
            return View(municipio);
        }

        // GET: Municipios/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var municipio = await _municipioRepository.GetAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }

          if (saveChangesError.GetValueOrDefault())
          {        // Utilizado para gerar mensagem ao excluir itens utilizados. Passado no try catch a validação.
            ViewData["ErrorMessage"] =
                " Não é possivel excluir esse item, pois está sendo utilizando por outra classe" ;
          }

            return View(municipio);
        }

        // POST: Municipios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var municipio = await _municipioRepository.SearchAsync(id);
                await _municipioRepository.DeleteAsync(municipio);
                
            }
            catch (DbUpdateException)
            {    
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true });
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool MunicipioExists(int id)
        {
            return _context.Municipios.Any(e => e.MunicipioId == id);
        }
    }
}
