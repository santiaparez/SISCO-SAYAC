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
    public class ContratistasController : Controller
    {
        private readonly SISCO_SAYACv3_5Context _context;

        public ContratistasController(SISCO_SAYACv3_5Context context)
        {
            _context = context;
        }

        // GET: Contratistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contratistas.ToListAsync());
        }

        // GET: Contratistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratistas = await _context.Contratistas
                .FirstOrDefaultAsync(m => m.ContratistasId == id);
            if (contratistas == null)
            {
                return NotFound();
            }

            return View(contratistas);
        }

        // GET: Contratistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contratistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratistasId,tipo_documento,numero_identificacion,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,telefono,direccion,correo_electronico")] Contratistas contratistas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratistas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contratistas);
        }

        // GET: Contratistas/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratistas = await _context.Contratistas.FindAsync(id);
            if (contratistas == null)
            {
                return NotFound();
            }
            return View(contratistas);
        }

        // POST: Contratistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratistasId,tipo_documento,numero_identificacion,primer_nombre,segundo_nombre,primer_apellido,segundo_apellido,telefono,direccion,correo_electronico")] Contratistas contratistas)
        {
            if (id != contratistas.ContratistasId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratistas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratistasExists(contratistas.ContratistasId))
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
            return View(contratistas);
        }

        // GET: Contratistas/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratistas = await _context.Contratistas
                .FirstOrDefaultAsync(m => m.ContratistasId == id);
            if (contratistas == null)
            {
                return NotFound();
            }

            return View(contratistas);
        }

        // POST: Contratistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratistas = await _context.Contratistas.FindAsync(id);
            _context.Contratistas.Remove(contratistas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratistasExists(int id)
        {
            return _context.Contratistas.Any(e => e.ContratistasId == id);
        }
    }
}
