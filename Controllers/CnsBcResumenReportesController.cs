using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiBuro.Models;

namespace ApiBuro.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("api/[controller]")]
    [ApiController]
    public class CnsBcResumenReportesController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcResumenReportesController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcResumenReportes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcResumenReporte>>> GetCnsBcResumenReporte()
        {
            return await _context.CnsBcResumenReporte.ToListAsync();
        }

        // GET: api/CnsBcResumenReportes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcResumenReporte>> GetCnsBcResumenReporte(string id)
        {
            var cnsBcResumenReporte = await _context.CnsBcResumenReporte.FindAsync(id);

            if (cnsBcResumenReporte == null)
            {
                return NotFound();
            }

            return cnsBcResumenReporte;
        }

        // PUT: api/CnsBcResumenReportes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcResumenReporte(string id, CnsBcResumenReporte cnsBcResumenReporte)
        {
            if (id != cnsBcResumenReporte.NumeroControlConsulta)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcResumenReporte).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcResumenReporteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CnsBcResumenReportes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcResumenReporte>> PostCnsBcResumenReporte(CnsBcResumenReporte cnsBcResumenReporte)
        {
            _context.CnsBcResumenReporte.Add(cnsBcResumenReporte);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CnsBcResumenReporteExists(cnsBcResumenReporte.NumeroControlConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCnsBcResumenReporte", new { id = cnsBcResumenReporte.NumeroControlConsulta }, cnsBcResumenReporte);
        }

        // DELETE: api/CnsBcResumenReportes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcResumenReporte>> DeleteCnsBcResumenReporte(string id)
        {
            var cnsBcResumenReporte = await _context.CnsBcResumenReporte.FindAsync(id);
            if (cnsBcResumenReporte == null)
            {
                return NotFound();
            }

            _context.CnsBcResumenReporte.Remove(cnsBcResumenReporte);
            await _context.SaveChangesAsync();

            return cnsBcResumenReporte;
        }

        private bool CnsBcResumenReporteExists(string id)
        {
            return _context.CnsBcResumenReporte.Any(e => e.NumeroControlConsulta == id);
        }
    }
}
