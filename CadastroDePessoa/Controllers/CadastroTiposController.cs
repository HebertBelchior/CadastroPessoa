using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroDePessoa;
using CadastroDePessoa.Data;

namespace CadastroDePessoa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroTiposController : ControllerBase
    {
        private readonly DataContext _context;

        public CadastroTiposController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CadastroTipos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CadastroTipo>>> GetCadastroTipos()
        {
          if (_context.CadastroTipos == null)
          {
              return NotFound();
          }
            return await _context.CadastroTipos.ToListAsync();
        }

        // GET: api/CadastroTipos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CadastroTipo>> GetCadastroTipo(int id)
        {
          if (_context.CadastroTipos == null)
          {
              return NotFound();
          }
            var cadastroTipo = await _context.CadastroTipos.FindAsync(id);

            if (cadastroTipo == null)
            {
                return NotFound();
            }

            return cadastroTipo;
        }

        // PUT: api/CadastroTipos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCadastroTipo(int id, CadastroTipo cadastroTipo)
        {
            if (id != cadastroTipo.Id)
            {
                return BadRequest();
            }

            _context.Entry(cadastroTipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CadastroTipoExists(id))
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

        // POST: api/CadastroTipos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CadastroTipo>> PostCadastroTipo(CadastroTipo cadastroTipo)
        {
          if (_context.CadastroTipos == null)
          {
              return Problem("Entity set 'DataContext.CadastroTipos'  is null.");
          }
            _context.CadastroTipos.Add(cadastroTipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCadastroTipo", new { id = cadastroTipo.Id }, cadastroTipo);
        }

        // DELETE: api/CadastroTipos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCadastroTipo(int id)
        {
            if (_context.CadastroTipos == null)
            {
                return NotFound();
            }
            var cadastroTipo = await _context.CadastroTipos.FindAsync(id);
            if (cadastroTipo == null)
            {
                return NotFound();
            }

            _context.CadastroTipos.Remove(cadastroTipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CadastroTipoExists(int id)
        {
            return (_context.CadastroTipos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
