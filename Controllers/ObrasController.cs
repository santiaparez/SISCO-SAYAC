using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SISCO_SAYACv3._5.Models;

namespace SISCO_SAYACv3._5.Controllers
{
    [Authorize]
    public class ObrasController : Controller
    {
        private readonly SISCO_SAYACv3_5Context _context;

        public ObrasController(SISCO_SAYACv3_5Context context)
        {
            _context = context;
        }

        // GET: Obras
        public async Task<IActionResult> Index()
        {
            var sISCO_SAYACv3_5Context = _context.Obras.Include(o => o.Contratos);
            return View(await sISCO_SAYACv3_5Context.ToListAsync());
        }

        // GET: Obras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .Include(o => o.Contratos)
                .FirstOrDefaultAsync(m => m.ObrasId == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        // GET: Obras/Create
        public IActionResult Create()
        {
       
            List<int> result = _context.Obras.Select(b => b.ContratosId).ToList();
            ViewData["ContratosId"]= new SelectList(_context.Contratos.Where(b => !result.Contains(b.ContratosId)), "ContratosId", "ContratosId");

            return View();
        }

        // POST: Obras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObrasId,nombre_obra,tipo_obra,direccion_obra,ContratosId")] Obras obras)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obras);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId", obras.ContratosId);
            return View(obras);
        }

        // GET: Obras/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras.FindAsync(id);
            if (obras == null)
            {
                return NotFound();
            }
            List<int> result = _context.Obras.Select(b => b.ContratosId).ToList();
            ViewData["ContratosId"] = new SelectList(_context.Contratos.Where(b => !result.Contains(b.ContratosId)), "ContratosId", "ContratosId");
            return View(obras);
        }

        // POST: Obras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObrasId,nombre_obra,tipo_obra,direccion_obra,ContratosId")] Obras obras)
        {
            if (id != obras.ObrasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obras);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObrasExists(obras.ObrasId))
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
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId", obras.ContratosId);
            return View(obras);
        }

        // GET: Obras/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obras = await _context.Obras
                .Include(o => o.Contratos)
                .FirstOrDefaultAsync(m => m.ObrasId == id);
            if (obras == null)
            {
                return NotFound();
            }

            return View(obras);
        }

        // POST: Obras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obras = await _context.Obras.FindAsync(id);
            _context.Obras.Remove(obras);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObrasExists(int id)
        {
            return _context.Obras.Any(e => e.ObrasId == id);
        }
    }
}
