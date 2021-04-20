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
    public class CnsBcHawkAlertCsController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcHawkAlertCsController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcHawkAlertCs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcHawkAlertC>>> GetCnsBcHawkAlertC()
        {
            return await _context.CnsBcHawkAlertC.ToListAsync();
        }

        // GET: api/CnsBcHawkAlertCs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcHawkAlertC>> GetCnsBcHawkAlertC(string id)
        {
            var cnsBcHawkAlertC = await _context.CnsBcHawkAlertC.FindAsync(id);

            if (cnsBcHawkAlertC == null)
            {
                return NotFound();
            }

            return cnsBcHawkAlertC;
        }

        // PUT: api/CnsBcHawkAlertCs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcHawkAlertC(string id, CnsBcHawkAlertC cnsBcHawkAlertC)
        {
            if (id != cnsBcHawkAlertC.NumeroControlConsulta)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcHawkAlertC).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcHawkAlertCExists(id))
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

        // POST: api/CnsBcHawkAlertCs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcHawkAlertC>> PostCnsBcHawkAlertC(CnsBcHawkAlertC cnsBcHawkAlertC)
        {
            _context.CnsBcHawkAlertC.Add(cnsBcHawkAlertC);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CnsBcHawkAlertCExists(cnsBcHawkAlertC.NumeroControlConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCnsBcHawkAlertC", new { id = cnsBcHawkAlertC.NumeroControlConsulta }, cnsBcHawkAlertC);
        }

        // DELETE: api/CnsBcHawkAlertCs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcHawkAlertC>> DeleteCnsBcHawkAlertC(string id)
        {
            var cnsBcHawkAlertC = await _context.CnsBcHawkAlertC.FindAsync(id);
            if (cnsBcHawkAlertC == null)
            {
                return NotFound();
            }

            _context.CnsBcHawkAlertC.Remove(cnsBcHawkAlertC);
            await _context.SaveChangesAsync();

            return cnsBcHawkAlertC;
        }

        private bool CnsBcHawkAlertCExists(string id)
        {
            return _context.CnsBcHawkAlertC.Any(e => e.NumeroControlConsulta == id);
        }
    }
}
