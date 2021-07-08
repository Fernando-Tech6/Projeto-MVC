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
    public class BairrosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IBairroRepository _bairroRepository;

        public BairrosController(ApplicationDbContext contexto, IBairroRepository bairroRepository)
        {
            _context = contexto;
            _bairroRepository = bairroRepository;
        }

        // GET: Bairros
        public async Task<IActionResult> Index()
        {
            return View(await _bairroRepository.ListaAsync());
        }

        // GET: Bairros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _bairroRepository.GetAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }

            return View(bairro);
        }

        // GET: Bairros/Create
        public IActionResult Create()
        {
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nome");
            return View();
        }

        // POST: Bairros/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BairroId,Nome,MunicipioId")] Bairro bairro)
        {
            if (ModelState.IsValid)
            {
                await _bairroRepository.CreateAsync(bairro);
                return RedirectToAction(nameof(Index));
            }

            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", bairro.MunicipioId);
            return View(bairro);
        }

        // GET: Bairros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _bairroRepository.SearchAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", bairro.MunicipioId);
            return View(bairro);
        }

        // POST: Bairros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BairroId,Nome,MunicipioId")] Bairro bairro)
        {
            if (id != bairro.BairroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bairroRepository.UpdateAsync(bairro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BairroExists(bairro.BairroId))
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
            ViewData["MunicipioId"] = new SelectList(_context.Municipios, "MunicipioId", "Nome", bairro.MunicipioId);
            return View(bairro);
        }

        // GET: Bairros/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bairro = await _bairroRepository.GetAsync(id);
            if (bairro == null)
            {
                return NotFound();
            }

          if (saveChangesError.GetValueOrDefault())
          {        // Utilizado para gerar mensagem ao excluir itens utilizados. Passado no try catch a validação.
                ViewData["ErrorMessage"] =
                " Não é possivel excluir esse item, pois está sendo utilizando por outra classe" ;
          }

            return View(bairro);
        }

        // POST: Bairros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var bairro = await _bairroRepository.SearchAsync(id);
                await _bairroRepository.DeleteAsync(bairro);
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException)
            {    
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true });
            }
        }

        private bool BairroExists(int id)
        {
            return _bairroRepository.Exists(id);
        }
    }
}
