using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Models;
using Microsoft.AspNetCore.Authorization;
using GftImoveis.Repositories;
using System;

namespace GftImoveis.Controllers
{
    [Authorize(Policy = "Adm")]
    public class QuartosController : Controller
    {
       private readonly IQuartoRepository _quartoRepository;

        public QuartosController( IQuartoRepository quartoRepository)
        {

            _quartoRepository = quartoRepository;
        }

        // GET: Quartos
        public async Task<IActionResult> Index()
        {

            return View(await _quartoRepository.ListaAsync());

        }

        // GET: Quartos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _quartoRepository.GetAsync(id);

            if (quarto == null)
            {
                return NotFound();
            }

            return View(quarto);
        }

        // GET: Quartos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Quartos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuartoId,Quantidade")] Quarto quarto)
        {
            if (ModelState.IsValid)
            {

              await _quartoRepository.CreateAsync(quarto);

                return RedirectToAction(nameof(Index));
            }
            return View(quarto);
        }

        // GET: Quartos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var quarto = await _quartoRepository.SearchAsync(id);
            if (quarto == null)
            {
                return NotFound();
            }
            return View(quarto);
        }

        // POST: Quartos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("QuartoId,Quantidade")] Quarto quarto)
        {
            if (id != quarto.QuartoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                   await _quartoRepository.UpdateAsync(quarto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuartoExists(quarto.QuartoId))
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
            return View(quarto);
        }

        // GET: Quartos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var quarto = await _quartoRepository.GetAsync(id);

            if (quarto == null)
            {
                return NotFound();
            }


          if (saveChangesError.GetValueOrDefault())
          {        // Utilizado para gerar mensagem ao excluir itens utilizados. Passado no try catch a validação.
            ViewData["ErrorMessage"] =
                " Não é possivel excluir esse item, pois está sendo utilizando por outra classe" ;
          }

            return View(quarto);
        }

        // POST: Quartos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {

                var quarto = await _quartoRepository.SearchAsync(id);
                await _quartoRepository.DeleteAsync(quarto);

            }
            catch (DbUpdateException)
            {    
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
        }

        private bool QuartoExists(int id)
        {
            return _quartoRepository.Exists(id);
        }
    }
}
