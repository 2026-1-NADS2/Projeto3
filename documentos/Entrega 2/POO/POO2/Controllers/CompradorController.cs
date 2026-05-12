using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POO2.Data;
using POO2.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompradorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public CompradorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddComprador([FromBody] Comprador comprador)
        {   
            comprador.saldo = 0;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Comprador.Add(comprador);
            await _appDbContext.SaveChangesAsync();

            return Created("Comprador adicionado com sucesso",comprador);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comprador>>> GetComprador()
        {
            var compradores = await _appDbContext.Comprador.ToListAsync();

            return Ok(compradores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comprador>> GetCompradorId(int id)
        {
            var Comprador = await _appDbContext.Comprador.FindAsync(id);
            if (Comprador == null)
            {
                return NotFound("Não encontrado");
            }

            return Ok(Comprador);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCompradorId(int id, [FromBody] Comprador compradorAtualizado)
        {
            var compradorAntigo = await _appDbContext.Comprador.FindAsync(id);
            if (compradorAntigo == null)
            {
                return NotFound("Não encontrado");
            }
            else
            {
                compradorAtualizado.cnpj = compradorAntigo.cnpj;
                compradorAtualizado.id = id;
                _appDbContext.Entry(compradorAntigo).CurrentValues.SetValues(compradorAtualizado);   
            }

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, compradorAntigo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompradorId(int id)
        {
            var Comprador = await _appDbContext.Comprador.FindAsync(id);
            if (Comprador == null)
            {
                return NotFound("Não encontrado");
            }

             _appDbContext.Comprador.Remove(Comprador);
             await _appDbContext.SaveChangesAsync();

             return Ok("Comprador deletado com sucesso");
        }
    }
}