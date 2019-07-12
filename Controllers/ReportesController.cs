using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using SISCO_SAYACv3._5.Models;

namespace SISCO_SAYACv3._5.Controllers
{
    [Authorize]
    public class ReportesController : Controller
    {
        private readonly SISCO_SAYACv3_5Context _context;

        public ReportesController(SISCO_SAYACv3_5Context context)
        {
            _context = context;
        }

        // GET: Reportes
        public async Task<IActionResult> Index()
        {
            var sISCO_SAYACv3_5Context = _context.Reportes.Include(r => r.Contratos);
            return View(await sISCO_SAYACv3_5Context.ToListAsync());
        }

        [HttpGet("exportv2")]
        public async Task<IActionResult> ExportV2()
        {
            // query data from database  
            await Task.Yield();
            var list =  (from e in _context.Reportes
                            join c in _context.Contratos on e.ContratosId equals c.ContratosId
                            select new
                            {
                                reporteid = e.ReportesId,
                                fecha = e.fecha_reportes,
                                nombre = e.nombre_reportes,
                                contratoId = c.ContratosId,
                                fecha_inicio = c.fecha_inicio.Date,
                                fecha_fin = c.fecha_fin.Date,
                                valor_contrato = c.valor_contrato,
                                tiempo_desfase = c.tiempo_desfase,
                                porcentaje_multa = c.porcentaje_multa,
                                porcentaje_adicional = c.porcentaje_adicional,
                                observaciones = c.observaciones,
                                estado = c.estado
                            }).ToList();
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Reporte-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        [HttpGet("exportv3")]
        public async Task<IActionResult> ExportV3(int? id)
        {
            // query data from database  
            await Task.Yield();
            var list = (from e in _context.Reportes where e.ReportesId == id
                        join c in _context.Contratos on e.ContratosId equals c.ContratosId
                        select new
                        {
                            reporteid = e.ReportesId,
                            fecha = e.fecha_reportes,
                            nombre = e.nombre_reportes,
                            contratoId = c.ContratosId,
                            fecha_inicio = c.fecha_inicio.Date,
                            fecha_fin = c.fecha_fin.Date,
                            valor_contrato = c.valor_contrato,
                            tiempo_desfase = c.tiempo_desfase,
                            porcentaje_multa = c.porcentaje_multa,
                            porcentaje_adicional = c.porcentaje_adicional,
                            observaciones = c.observaciones,
                            estado = c.estado
                        }).ToList();
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                var workSheet = package.Workbook.Worksheets.Add("Sheet1");
                workSheet.Cells.LoadFromCollection(list, true);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Reporte-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";

            //return File(stream, "application/octet-stream", excelName);  
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        // GET: Reportes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes
                .Include(r => r.Contratos)
                .FirstOrDefaultAsync(m => m.ReportesId == id);
            if (reportes == null)
            {
                return NotFound();
            }

            return View(reportes);
        }

        // GET: Reportes/Create
        public IActionResult Create()
        {
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId");
            ViewData["ObrasId"] = new SelectList(_context.Obras, "ObrasId", "nombre_obra");
            return View();
        }

        // POST: Reportes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReportesId,nombre_reportes,fecha_reportes,observacion,ContratosId")] Reportes reportes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reportes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId", reportes.ContratosId);
            return View(reportes);
        }

        /*[HttpPost("CrearConsulta")]
        public async Task<IActionResult> CrearConsulta([Bind("NombreConsulta,FechaContratoInferior,FechaContratoSuperior,Contratista,Obra,PorcentajeAvanceInferior,PorcentajeAvanceSuperior,MontoInferior,MontoSuperior,Activo,Terminado")] Consultas consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return BadRequest();
        }*/

        // TODO: hacer esta funcion
        /*public async Task<IActionResult> GenerarReporteObras(Consulta consulta)
        {
            return View();
        }*/

        // GET: Reportes/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes.FindAsync(id);
            if (reportes == null)
            {
                return NotFound();
            }
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId", reportes.ContratosId);
            return View(reportes);
        }

        // POST: Reportes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReportesId,nombre_reportes,fecha_reportes,observacion,ContratosId")] Reportes reportes)
        {
            if (id != reportes.ReportesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reportes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReportesExists(reportes.ReportesId))
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
            ViewData["ContratosId"] = new SelectList(_context.Contratos, "ContratosId", "ContratosId", reportes.ContratosId);
            return View(reportes);
        }

        // GET: Reportes/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reportes = await _context.Reportes
                .Include(r => r.Contratos)
                .FirstOrDefaultAsync(m => m.ReportesId == id);
            if (reportes == null)
            {
                return NotFound();
            }

            return View(reportes);
        }

        // POST: Reportes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reportes = await _context.Reportes.FindAsync(id);
            _context.Reportes.Remove(reportes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReportesExists(int id)
        {
            return _context.Reportes.Any(e => e.ReportesId == id);
        }
    }
}
