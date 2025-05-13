using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Practica.Server.Models;
using Practica.Server.Models.Medicamentos;

namespace Practica.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly MedicamentosContext _context;
        public CategoriaController(MedicamentosContext context)
        {
            _context = context;
        }


        [HttpPost]
        [Route("InsertarCategoria")]
        public async Task<IActionResult> InsertarCategoria(Categoria categoria)
        {
            await _context.Categoria.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }


        [HttpGet]
        [Route("ListarCategoria")]
        public async Task<List<Categoria>> ListarCategoria()
        {
            var categoria = await _context.Categoria
                .Include(c => c.EstadoFk)
                .ToListAsync();
            return categoria;
        }


        [HttpGet]
        [Route("ConsultarCategoria")]
        public async Task <Categoria> ConsultarCategoria(int id)
        {
            var categoriaConsultar = await _context.Categoria
                .Include(c => c.EstadoFk)
                .FirstOrDefaultAsync(c => c.id == id);
                return categoriaConsultar;
        }
       
        
        [HttpPut]
        [Route("ActualizarCategoria")]
        public async Task <IActionResult> ActualizarCategoria(Categoria categoria)
        {
            var categoriaExistente = await _context.Categoria.FirstOrDefaultAsync(c => c.id == categoria.id);
            if (categoriaExistente == null)
            {
                return BadRequest();
            }
            categoriaExistente.descripcionCategoria = categoria.descripcionCategoria;
            categoriaExistente.estadoCategoria = categoria.estadoCategoria;
            _context.Categoria.Update(categoriaExistente);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpDelete]
        [Route("EliminarCategoria")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            var categoriaEliminada = await _context.Categoria.FindAsync(id);
            if (categoriaEliminada == null)
            {
                return BadRequest();
            }
            _context.Categoria.Remove(categoriaEliminada);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
