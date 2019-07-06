using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SISCO_SAYACv3._5.Models;

namespace SISCO_SAYACv3._5.Controllers
{

    [Authorize]
    public class ContratosController : Controller
    {
        private readonly SISCO_SAYACv3_5Context _context;

        public ContratosController(SISCO_SAYACv3_5Context context)
        {
            _context = context;
        }

        // GET: Contratos
        
        public async Task<IActionResult> Index()
        {
            var sISCO_SAYACv3_5Context = _context.Contratos.Include(c => c.Contratistas);
            return View(await sISCO_SAYACv3_5Context.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Contratistas)
                .FirstOrDefaultAsync(m => m.ContratosId == id);
            if (contratos == null)
            {
                return NotFound();
            }

            string VMulta = CalcularValorMulta(contratos);
            ViewBag.ValorMulta = VMulta;

            string TDesfase = CalcularTiempoDesfase(contratos);
            ViewBag.TiempoDesfase = TDesfase;

            return View(contratos);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["ContratistasId"] = new SelectList(_context.Contratistas, "ContratistasId", "numero_identificacion");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratosId,fecha_inicio,fecha_fin,valor_contrato,tiempo_desfase,porcentaje_multa,porcentaje_adicional,observaciones,estado,ContratistasId")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratistasId"] = new SelectList(_context.Contratistas, "ContratistasId", "numero_identificacion", contratos.ContratistasId);
            return View(contratos);
        }

        // GET: Contratos/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos.FindAsync(id);
            if (contratos == null)
            {
                return NotFound();
            }
            ViewData["ContratistasId"] = new SelectList(_context.Contratistas, "ContratistasId", "numero_identificacion", contratos.ContratistasId);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratosId,fecha_inicio,fecha_fin,valor_contrato,tiempo_desfase,porcentaje_multa,porcentaje_adicional,observaciones,estado,ContratistasId")] Contratos contratos)
        {
            if (id != contratos.ContratosId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratosExists(contratos.ContratosId))
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
            ViewData["ContratistasId"] = new SelectList(_context.Contratistas, "ContratistasId", "numero_identificacion", contratos.ContratistasId);
            return View(contratos);
        }

        // GET: Contratos/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Contratistas)
                .FirstOrDefaultAsync(m => m.ContratosId == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratos = await _context.Contratos.FindAsync(id);
            _context.Contratos.Remove(contratos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratosExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratosId == id);
        }

        public string CalcularValorMulta(Contratos contrato)
        {
            double valorMulta = 0;
            string VMulta = "";

            var currentDay = DateTime.Now.Day == 31 ? 30 : DateTime.Now.Day;
            var currentDay2 = contrato.fecha_fin.Day == 31 && (DateTime.Now.Day == 30 || DateTime.Now.Day == 31) ? 30 : contrato.fecha_fin.Day;
            var d1 = contrato.fecha_inicio.Day == 31 ? 30 : contrato.fecha_inicio.Day;
            var d2 = contrato.fecha_fin.Day == 31 && (contrato.fecha_inicio.Day == 30 || contrato.fecha_inicio.Day == 31) ? 30 : contrato.fecha_fin.Day;
            var DiffActDay = (contrato.fecha_fin - contrato.fecha_inicio).TotalDays;
            double newDayDiff = ((360 * (contrato.fecha_fin.Year - contrato.fecha_inicio.Year)) + (30 * (contrato.fecha_fin.Month - contrato.fecha_inicio.Month)) + (d1 - d2));
            double tiempoDesfase = ((360 * (DateTime.Now.Year - contrato.fecha_fin.Year)) + (30 * (DateTime.Now.Month - contrato.fecha_fin.Month)) + (currentDay - currentDay2));

            double porcentajeDesfase = (tiempoDesfase / newDayDiff) * 100;

            if (tiempoDesfase > 0)
            {
                double multiplicador = Math.Floor(porcentajeDesfase / contrato.tiempo_desfase);

                valorMulta = contrato.valor_contrato * (contrato.porcentaje_multa + (contrato.porcentaje_adicional * multiplicador)) / 100;

                VMulta = string.Format("${0:0.000}", valorMulta.ToString());
            }


            return VMulta;
        }

        public string CalcularTiempoDesfase(Contratos contrato)
        {
            var currentDay = DateTime.Now.Day == 31 ? 30 : DateTime.Now.Day;
            var currentDay2 = contrato.fecha_fin.Day == 31 && (DateTime.Now.Day == 30 || DateTime.Now.Day == 31) ? 30 : contrato.fecha_fin.Day;
            int tiempoDesfase = ((360 * (DateTime.Now.Year - contrato.fecha_fin.Year)) + (30 * (DateTime.Now.Month - contrato.fecha_fin.Month)) + (currentDay - currentDay2));
            string TDesfase = "";

            if (tiempoDesfase > 0)
            {
                TDesfase = (tiempoDesfase.ToString() + " Dias");
            }

            if (tiempoDesfase <= 0)
            {
                TDesfase = "No hay tiempo de desfase.";
            }


            return TDesfase;
        }
    }
}
