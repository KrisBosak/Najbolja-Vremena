using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Najbolja_Vremena.Data;
using Najbolja_Vremena.Models;


namespace Najbolja_Vremena.Controllers
{
    public class VremenasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VremenasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Vremenas
        public IActionResult Index()
        {
            var vremena = _context.Vremena.AsQueryable();
            
            vremena = vremena.OrderBy(v => v.Vrijeme.TimeOfDay);

            return View(vremena);
        }

        [Authorize]
        public async Task<IActionResult> Administracija()
        {
            return View(await _context.Vremena.ToListAsync());
        }

        // GET: Vremenas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vremenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Prezime,Vrijeme,Potvrdeno")] Vremena vremena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vremena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vremena);
        }

        // GET: Vremenas/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vremena = await _context.Vremena.FindAsync(id);
            if (vremena == null)
            {
                return NotFound();
            }
            return View(vremena);
        }

        // POST: Vremenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Prezime,Vrijeme,Potvrdeno")] Vremena vremena)
        {
            if (id != vremena.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vremena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VremenaExists(vremena.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Administracija));
            }
            return View(vremena);
        }

        // GET: Vremenas/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vremena = await _context.Vremena
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vremena == null)
            {
                return NotFound();
            }

            return View(vremena);
        }

        // POST: Vremenas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vremena = await _context.Vremena.FindAsync(id);
            _context.Vremena.Remove(vremena);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VremenaExists(int id)
        {
            return _context.Vremena.Any(e => e.Id == id);
        }
    }
}
