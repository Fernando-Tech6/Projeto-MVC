using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GftImoveis.Models;
using GftImoveis.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace GftImoveis.Controllers
{
    [Authorize(Policy = "Adm")]
    public class EnderecosController : Controller
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecosController(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        // GET: Enderecos
        public async Task<IActionResult> Index()
        {
            return View(await _enderecoRepository.ListaAsync());
        }

        // GET: Enderecos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _enderecoRepository.GetAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return View(endereco);
        }

        // GET: Enderecos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Enderecos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnderecoId,Nome,UF")] Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                await _enderecoRepository.CreateAsync(endereco);

                return RedirectToAction(nameof(Index));
            }
            return View(endereco);
        }

        // GET: Enderecos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _enderecoRepository.SearchAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }
            return View(endereco);
        }

        // POST: Enderecos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnderecoId,Nome,UF")] Endereco endereco)
        {
            if (id != endereco.EnderecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _enderecoRepository.UpdateAsync(endereco);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EnderecoExists(endereco.EnderecoId))
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
            return View(endereco);
        }

        // GET: Enderecos/Delete/5
        public async Task<IActionResult> Delete(int? id, bool? saveChangesError)
        {
            if (id == null)
            {
                return NotFound();
            }

            var endereco = await _enderecoRepository.GetAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

          if (saveChangesError.GetValueOrDefault())
          {        // Utilizado para gerar mensagem ao excluir itens utilizados. Passado no try catch a validação.
            ViewData["ErrorMessage"] =
                " Não é possivel excluir esse item, pois está sendo utilizando por outra classe" ;
          }

            return View(endereco);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            try
            {
                var endereco = await _enderecoRepository.SearchAsync(id);
                await _enderecoRepository.DeleteAsync(endereco);
            
            }
            catch (DbUpdateException)
            {    
                return RedirectToAction(nameof(Delete), new {id = id, saveChangesError = true });
            }

            return RedirectToAction(nameof(Index));
            
        }

        private bool EnderecoExists(int id)
        {
            return _enderecoRepository.Exists(id);
        }
    }
}
