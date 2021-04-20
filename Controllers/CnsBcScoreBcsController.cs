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
    public class CnsBcScoreBcsController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcScoreBcsController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcScoreBcs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcScoreBc>>> GetCnsBcScoreBc()
        {
            return await _context.CnsBcScoreBc.ToListAsync();
        }

        // GET: api/CnsBcScoreBcs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcScoreBc>> GetCnsBcScoreBc(string id)
        {
            var cnsBcScoreBc = await _context.CnsBcScoreBc.FindAsync(id);

            if (cnsBcScoreBc == null)
            {
                return NotFound();
            }

            return cnsBcScoreBc;
        }

        // PUT: api/CnsBcScoreBcs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcScoreBc(string id, CnsBcScoreBc cnsBcScoreBc)
        {
            if (id != cnsBcScoreBc.NumeroControlConsulta)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcScoreBc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcScoreBcExists(id))
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

        // POST: api/CnsBcScoreBcs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcScoreBc>> PostCnsBcScoreBc(CnsBcScoreBc cnsBcScoreBc)
        {
            _context.CnsBcScoreBc.Add(cnsBcScoreBc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CnsBcScoreBcExists(cnsBcScoreBc.NumeroControlConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCnsBcScoreBc", new { id = cnsBcScoreBc.NumeroControlConsulta }, cnsBcScoreBc);
        }

        // DELETE: api/CnsBcScoreBcs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcScoreBc>> DeleteCnsBcScoreBc(string id)
        {
            var cnsBcScoreBc = await _context.CnsBcScoreBc.FindAsync(id);
            if (cnsBcScoreBc == null)
            {
                return NotFound();
            }

            _context.CnsBcScoreBc.Remove(cnsBcScoreBc);
            await _context.SaveChangesAsync();

            return cnsBcScoreBc;
        }

        private bool CnsBcScoreBcExists(string id)
        {
            return _context.CnsBcScoreBc.Any(e => e.NumeroControlConsulta == id);
        }
    }
}
