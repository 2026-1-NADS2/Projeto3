using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using POO2.Data;
using POO2.Models;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public VendedorController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddVendedor([FromBody] Vendedor vendedor)
        {
            vendedor.anuncios = null;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.Vendedor.Add(vendedor);
            await _appDbContext.SaveChangesAsync();

            return Created("Vendedor adicionado com sucesso",vendedor);
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendedor>>> GetVendedor()
        {
            var vendedores = await _appDbContext.Vendedor.ToListAsync();

            return Ok(vendedores);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Vendedor>> GetVendedorId(int id)
        {
            var vendedor = await _appDbContext.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound("Não encontrado");
            }

            return Ok(vendedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendedorId(int id, [FromBody] Vendedor vendedorAtualizado)
        {
            var vendedorAntigo = await _appDbContext.Vendedor.FindAsync(id);
            if (vendedorAntigo == null)
            {
                return NotFound("Não encontrado");
            }
            else
            {
                vendedorAtualizado.cnpj = vendedorAntigo.cnpj;
                vendedorAtualizado.id = id;
                _appDbContext.Entry(vendedorAntigo).CurrentValues.SetValues(vendedorAtualizado);   
            }

            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, vendedorAntigo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendedorId(int id)
        {
            var vendedor = await _appDbContext.Vendedor.FindAsync(id);
            if (vendedor == null)
            {
                return NotFound("Não encontrado");
            }

             _appDbContext.Vendedor.Remove(vendedor);
             await _appDbContext.SaveChangesAsync();

             return Ok("Vendedor deletado com sucesso");
        }
    }
}