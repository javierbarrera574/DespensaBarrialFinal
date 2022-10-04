using DespensaBarrialFinal.BD.Datos;
using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.Server.Controllers
{
    [ApiController]
    [Route("api/Categorias")]
    public class CategoriasControlador : ControllerBase
    {

        private readonly AplicacionDbContext context;

        public CategoriasControlador(AplicacionDbContext context)
        {
            this.context = context;
        }

        [HttpGet]//esta bien
        public async Task<ActionResult<List<Categorias>>> Get()
        {
            var respuesta = await context.Categorias.ToListAsync();
            return respuesta;
        }

        [HttpPost]

        public async Task<ActionResult<Categorias>> Post(Categorias categorias)
        {
            try
            {
                context.Categorias.Add(categorias);
                await context.SaveChangesAsync();
                return categorias;

            }
            catch (Exception p)
            {
                return BadRequest(p.Message);
            }
        }


        [HttpPost("{id:int}")]

        public async Task<ActionResult<Categorias>> AgregarProductoConCategoria(int id)
        {

            var productos_categoria = context.Productos.
                Where(c => c.Id == id).
                Include(c => c.NombreProducto).
                Include(n => n.DescripcionProducto).
                Include(f => f.FechaVencimientoProducto).
                Include(p => p.PrecioProducto).
                Include(c => c.Categorias).
                FirstOrDefaultAsync();



            context.Add(productos_categoria);
            await context.SaveChangesAsync();
            return Ok();
        }

    }
}
