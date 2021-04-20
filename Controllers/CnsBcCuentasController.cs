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
    [Route("api/[controller]")]
    [ApiController]
    public class CnsBcCuentasController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcCuentasController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcCuentas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcCuenta>>> GetCnsBcCuenta()
        {
            return await _context.CnsBcCuenta.ToListAsync();
        }

        // GET: api/CnsBcCuentas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcCuenta>> GetCnsBcCuenta(string id)
        {
            var cnsBcCuenta = await _context.CnsBcCuenta.FindAsync(id);

            if (cnsBcCuenta == null)
            {
                return NotFound();
            }

            return cnsBcCuenta;
        }

        // PUT: api/CnsBcCuentas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcCuenta(string id, CnsBcCuenta cnsBcCuenta)
        {
            if (id != cnsBcCuenta.NumeroControlConsulta)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcCuenta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcCuentaExists(id))
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

        // POST: api/CnsBcCuentas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcCuenta>> PostCnsBcCuenta(CnsBcCuenta cnsBcCuenta)
        {
            _context.CnsBcCuenta.Add(cnsBcCuenta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CnsBcCuentaExists(cnsBcCuenta.NumeroControlConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCnsBcCuenta", new { id = cnsBcCuenta.NumeroControlConsulta }, cnsBcCuenta);
        }

        // DELETE: api/CnsBcCuentas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcCuenta>> DeleteCnsBcCuenta(string id)
        {
            var cnsBcCuenta = await _context.CnsBcCuenta.FindAsync(id);
            if (cnsBcCuenta == null)
            {
                return NotFound();
            }

            _context.CnsBcCuenta.Remove(cnsBcCuenta);
            await _context.SaveChangesAsync();

            return cnsBcCuenta;
        }

        private bool CnsBcCuentaExists(string id)
        {
            return _context.CnsBcCuenta.Any(e => e.NumeroControlConsulta == id);
        }
    }
}
