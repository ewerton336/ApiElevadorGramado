using ApiElevadorGramado.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiElevadorGramado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AvisosController : ControllerBase
    {
        private readonly AvisosContext _context;

        public AvisosController(AvisosContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aviso>>> GetAvisos()
        {
            return await _context.Avisos.ToListAsync();
        }

        //método para buscar ultimo aviso
        [HttpGet("ultimo")]
        public async Task<ActionResult<Aviso>> GetUltimoAviso()
        {
            return await _context.Avisos.OrderByDescending(a => a.Id).FirstOrDefaultAsync();
        }


        [HttpPost]
        public async Task<ActionResult<Aviso>> PostAviso([FromBody] Aviso aviso)
        {
            _context.Avisos.Add(aviso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAvisos), new { id = aviso.Id }, aviso);
        }

    }
}
