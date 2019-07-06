using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SISCO_SAYACv3._5.Models;

namespace SISCO_SAYACv3._5.Controllers
{
    public class AuditoriasController : Controller
    {
        private readonly SISCO_SAYACv3_5Context _context;

        public AuditoriasController(SISCO_SAYACv3_5Context context)
        {
            _context = context;
        }

        // GET: Auditorias
        public async Task<IActionResult> Index()
        {
            var sISCO_SAYACv3_5Context = _context.Auditorias.Include(a => a.Usuarios);
            return View(await sISCO_SAYACv3_5Context.ToListAsync());
        }

        // GET: Auditorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorias = await _context.Auditorias
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.AuditoriasId == id);
            if (auditorias == null)
            {
                return NotFound();
            }

            return View(auditorias);
        }

        // GET: Auditorias/Create
        public IActionResult Create()
        {
            ViewData["UsuariosId"] = new SelectList(_context.Set<Usuarios>(), "UsuariosId", "contrasena");
            return View();
        }

        // POST: Auditorias/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AuditoriasId,Fecha_Inicio,Fecha_Final,UsuariosId")] Auditorias auditorias)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auditorias);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UsuariosId"] = new SelectList(_context.Set<Usuarios>(), "UsuariosId", "contrasena", auditorias.UsuariosId);
            return View(auditorias);
        }

        // GET: Auditorias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorias = await _context.Auditorias.FindAsync(id);
            if (auditorias == null)
            {
                return NotFound();
            }
            ViewData["UsuariosId"] = new SelectList(_context.Set<Usuarios>(), "UsuariosId", "contrasena", auditorias.UsuariosId);
            return View(auditorias);
        }

        // POST: Auditorias/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AuditoriasId,Fecha_Inicio,Fecha_Final,UsuariosId")] Auditorias auditorias)
        {
            if (id != auditorias.AuditoriasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auditorias);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AuditoriasExists(auditorias.AuditoriasId))
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
            ViewData["UsuariosId"] = new SelectList(_context.Set<Usuarios>(), "UsuariosId", "contrasena", auditorias.UsuariosId);
            return View(auditorias);
        }

        // GET: Auditorias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var auditorias = await _context.Auditorias
                .Include(a => a.Usuarios)
                .FirstOrDefaultAsync(m => m.AuditoriasId == id);
            if (auditorias == null)
            {
                return NotFound();
            }

            return View(auditorias);
        }

        // POST: Auditorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var auditorias = await _context.Auditorias.FindAsync(id);
            _context.Auditorias.Remove(auditorias);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuditoriasExists(int id)
        {
            return _context.Auditorias.Any(e => e.AuditoriasId == id);
        }
    }
}
