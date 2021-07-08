using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Models;
using Microsoft.AspNetCore.Authorization;
using GftImoveis.Repositories;

namespace GftImoveis.Controllers
{
    [Authorize(Policy = "Adm")]
    public class NegociosController : Controller
    {
       
        private readonly INegocioRepository _negocioRepository;

        public NegociosController(INegocioRepository negocioRepository)
        {
           
            _negocioRepository = negocioRepository;
        }

        // GET: Negocios
        public async Task<IActionResult> Index()
        {
            return View(await _negocioRepository.ListaAsync());
        }

        // GET: Negocios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocio = await _negocioRepository.GetAsync(id);

            if (negocio == null)
            {
                return NotFound();
            }

            return View(negocio);
        }

        // GET: Negocios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Negocios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NegocioId,Nome")] Negocio negocio)
        {
            if (ModelState.IsValid)
            {
                await _negocioRepository.CreateAsync(negocio);

                return RedirectToAction(nameof(Index));
            }
            return View(negocio);
        }

        // GET: Negocios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocio = await _negocioRepository.SearchAsync(id);

            if (negocio == null)
            {
                return NotFound();
            }
            return View(negocio);
        }

        // POST: Negocios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NegocioId,Nome")] Negocio negocio)
        {
            if (id != negocio.NegocioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _negocioRepository.UpdateAsync(negocio);
                }   
                catch (DbUpdateConcurrencyException)
                {
                    if (!NegocioExists(negocio.NegocioId))
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
            return View(negocio);
        }

        // GET: Negocios/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var negocio = await _negocioRepository.GetAsync(id);

            if (negocio == null)
            {
                return NotFound();
            }


          if (saveChangesError.GetValueOrDefault())
          {        // Utilizado para gerar mensagem ao excluir itens utilizados. Passado no try catch a validação.
            ViewData["ErrorMessage"] =
                " Não é possivel excluir esse item, pois está sendo utilizando por outra classe" ;
          }

            return View(negocio);
        }

        // POST: Negocios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var negocio = await _negocioRepository.SearchAsync(id);
                await _negocioRepository.DeleteAsync(negocio);
            }
            catch (DbUpdateException)
            {    
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NegocioExists(int id)
        {
            return _negocioRepository.Exists(id);
        }
    }
}
