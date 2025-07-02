using Microsoft.AspNetCore.Mvc;
using UnescCRM.Models;
using Microsoft.EntityFrameworkCore;
using UnescCRM.Models.Data;

namespace UnescCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManifestacaoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManifestacaoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Manifestacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manifestacao>>> GetManifestacoes()
        {
            return await _context.Manifestacoes.Include(m => m.Usuario).ToListAsync();
        }

        // GET: /Manifestacao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Manifestacao>> GetManifestacao(int id)
        {
            var manifestacao = await _context.Manifestacoes
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (manifestacao == null)
            {
                return NotFound();
            }

            return manifestacao;
        }

        // POST: /Manifestacao
        [HttpPost]
        public async Task<ActionResult<Manifestacao>> CreateManifestacao(Manifestacao manifestacao)
        {
            _context.Manifestacoes.Add(manifestacao);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetManifestacao), new { id = manifestacao.Id }, manifestacao);
        }

        // PUT: /Manifestacao/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateManifestacao(int id, Manifestacao manifestacao)
        {
            if (id != manifestacao.Id)
            {
                return BadRequest();
            }

            _context.Entry(manifestacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManifestacaoExists(id))
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

        // DELETE: /Manifestacao/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManifestacao(int id)
        {
            var manifestacao = await _context.Manifestacoes.FindAsync(id);
            if (manifestacao == null)
            {
                return NotFound();
            }

            _context.Manifestacoes.Remove(manifestacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManifestacaoExists(int id)
        {
            return _context.Manifestacoes.Any(e => e.Id == id);
        }
    }
}