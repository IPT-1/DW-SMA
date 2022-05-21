using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SMA.Data;
using SMA.Models;

namespace SMA.Controllers
{
    public class UtentesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UtentesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
              return View(await _context.Utentes.ToListAsync());
        }

        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            var utente = await _context.Utentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // GET: Utentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Telemovel,NumeroUtenteSaude,Sexo,Tipo")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return RedirectToAction("Index");
            }

            var utente = await _context.Utentes.FindAsync(id);
            if (utente == null)
            {
                return RedirectToAction("Index");
            }
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Telemovel,NumeroUtenteSaude,Sexo,Tipo")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            var utentesIDPreviouslyStored = HttpContext.Session.GetInt32("UtenteID");

            if (utentesIDPreviouslyStored == null) {
                ModelState.AddModelError("","Você passou o limite de tempo...");
                return View(utente);
            }

            if (utentesIDPreviouslyStored != utente.Id) {
                return RedirectToAction("Index");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
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
            return View(utente);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Utentes == null)
            {
                return NotFound();
            }

            var utente = await _context.Utentes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Utentes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Utentes'  is null.");
            }
            var utente = await _context.Utentes.FindAsync(id);
            if (utente != null)
            {
                _context.Utentes.Remove(utente);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteExists(int id)
        {
          return _context.Utentes.Any(e => e.Id == id);
        }
    }
}
