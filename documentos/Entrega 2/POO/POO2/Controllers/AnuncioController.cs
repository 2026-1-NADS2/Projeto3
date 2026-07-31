using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POO2.Data;
using POO2.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnuncioController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public AnuncioController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAnuncio([FromBody] Anuncio anuncio)
        {   
            var fornecedor = await _appDbContext.Vendedor.FirstOrDefaultAsync(v => v.cnpj == anuncio.fornecedor);
            if(fornecedor.cnpj != anuncio.fornecedor || anuncio.fornecedor == null)
            {
                return NotFound("Fornecedor não encontrado no banco");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Anuncio.Add(anuncio);
            await _appDbContext.SaveChangesAsync();

            return Created("Anuncio adicionado com sucesso",anuncio);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anuncio>>> GetAnuncio()
        {
            var anuncios = await _appDbContext.Anuncio.ToListAsync();

            return Ok(anuncios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Anuncio>> GetAnuncioId(int id)
        {
            var anuncio = await _appDbContext.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound("Não encontrado");
            }

            return Ok(anuncio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAnuncioId(int id, [FromBody] Anuncio anuncioAtualizado)
        {
            var anuncioAntigo = await _appDbContext.Anuncio.FindAsync(id);
            var cnpj = anuncioAntigo.fornecedor;
            if (anuncioAntigo == null)
            {
                return NotFound("Não encontrado");
            }
            else
            {
                anuncioAtualizado.fornecedor = cnpj;
                anuncioAtualizado.id = id;
                _appDbContext.Entry(anuncioAntigo).CurrentValues.SetValues(anuncioAtualizado);   
            }

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, anuncioAntigo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnuncioId(int id)
        {
            var anuncio = await _appDbContext.Anuncio.FindAsync(id);
            if (anuncio == null)
            {
                return NotFound("Não encontrado");
            }

             _appDbContext.Anuncio.Remove(anuncio);
             await _appDbContext.SaveChangesAsync();

             return Ok("Anuncio deletado com sucesso");
        }
    }
}