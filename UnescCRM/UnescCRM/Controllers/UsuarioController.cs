using Microsoft.AspNetCore.Mvc;
using UnescCRM.Models.Data;
using UnescCRM.Models;
using Microsoft.EntityFrameworkCore;

namespace UnescCRM.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: /Usuario/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // GET: /Usuario/nome/{nome}
        [HttpGet("nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarioPorNome(string nome)
        {
            var usuarios = await _context.Usuarios
                .Where(u => EF.Functions.ILike(u.Nome, $"%{nome}%")) // Busca case-insensitive com LIKE
                .ToListAsync();

            if (usuarios == null || usuarios.Count == 0)
            {
                return NotFound();
            }

            return usuarios;
        }

        // GET: /Usuario/login/{login}
        [HttpGet("login/{login}")]
        public async Task<ActionResult<Usuario>> GetUsuarioPorLogin(int login)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Login == login);

            if (usuario == null)
            {
                return NotFound();
            }

            return usuario;
        }

        // POST: /Usuario
        [HttpPost]
        public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsuario), new { id = usuario.Id }, usuario);
        }

        // PUT: /Usuario/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // DELETE: /Usuario/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}