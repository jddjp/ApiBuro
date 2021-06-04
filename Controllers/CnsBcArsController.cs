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
    [ApiController]
    [Route("api/[controller]")]
    public class CnsBcArsController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcArsController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcArs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcAr>>> GetCnsBcAr()
        {
            return await _context.CnsBcAr.ToListAsync();
        }

        // GET: api/CnsBcArs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcAr>> GetCnsBcAr(int? id)
        {
            var cnsBcAr = await _context.CnsBcAr.FindAsync(id);

            if (cnsBcAr == null)
            {
                return NotFound();
            }

            return cnsBcAr;
        }

        // PUT: api/CnsBcArs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcAr(int? id, CnsBcAr cnsBcAr)
        {
            if (id != cnsBcAr.PkAr)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcAr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcArExists(id))
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

        // POST: api/CnsBcArs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcAr>> PostCnsBcAr(CnsBcAr cnsBcAr)
        {
            _context.CnsBcAr.Add(cnsBcAr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCnsBcAr", new { id = cnsBcAr.PkAr }, cnsBcAr);
        }

        // DELETE: api/CnsBcArs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcAr>> DeleteCnsBcAr(int? id)
        {
            var cnsBcAr = await _context.CnsBcAr.FindAsync(id);
            if (cnsBcAr == null)
            {
                return NotFound();
            }

            _context.CnsBcAr.Remove(cnsBcAr);
            await _context.SaveChangesAsync();

            return cnsBcAr;
        }

        private bool CnsBcArExists(int? id)
        {
            return _context.CnsBcAr.Any(e => e.PkAr == id);
        }
    }
}
