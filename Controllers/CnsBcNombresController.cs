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
    public class CnsBcNombresController : ControllerBase
    {
        private readonly ApiSICContext _context;

        public CnsBcNombresController(ApiSICContext context)
        {
            _context = context;
        }

        // GET: api/CnsBcNombres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CnsBcNombre>>> GetCnsBcNombre()
        {
            return await _context.CnsBcNombre.ToListAsync();
        }

        // GET: api/CnsBcNombres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CnsBcNombre>> GetCnsBcNombre(string id)
        {
            var cnsBcNombre = await _context.CnsBcNombre.FindAsync(id);

            if (cnsBcNombre == null)
            {
                return NotFound();
            }

            return cnsBcNombre;
        }

        // PUT: api/CnsBcNombres/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCnsBcNombre(string id, CnsBcNombre cnsBcNombre)
        {
            if (id != cnsBcNombre.NumeroControlConsulta)
            {
                return BadRequest();
            }

            _context.Entry(cnsBcNombre).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CnsBcNombreExists(id))
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

        // POST: api/CnsBcNombres
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CnsBcNombre>> PostCnsBcNombre(CnsBcNombre cnsBcNombre)
        {
            _context.CnsBcNombre.Add(cnsBcNombre);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CnsBcNombreExists(cnsBcNombre.NumeroControlConsulta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCnsBcNombre", new { id = cnsBcNombre.NumeroControlConsulta }, cnsBcNombre);
        }

        // DELETE: api/CnsBcNombres/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CnsBcNombre>> DeleteCnsBcNombre(string id)
        {
            var cnsBcNombre = await _context.CnsBcNombre.FindAsync(id);
            if (cnsBcNombre == null)
            {
                return NotFound();
            }

            _context.CnsBcNombre.Remove(cnsBcNombre);
            await _context.SaveChangesAsync();

            return cnsBcNombre;
        }

        private bool CnsBcNombreExists(string id)
        {
            return _context.CnsBcNombre.Any(e => e.NumeroControlConsulta == id);
        }
    }
}
