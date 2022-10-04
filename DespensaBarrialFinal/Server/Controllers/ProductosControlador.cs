using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using DespensaBarrialFinal.BD.Datos;

namespace DespensaBarrialFinal.Server.Controllers
{

    [ApiController]

    [Route("api/Productos")]

    public class ProductosControlador : ControllerBase
    {
        private readonly AplicacionDbContext context;

        public ProductosControlador(AplicacionDbContext contexto)
        {
            this.context = contexto;
       
        }


        [HttpGet]//esta bien
        public async Task<ActionResult<List<Productos>>> Get()
        {
            var respuesta = await context.Productos.ToListAsync();
            return respuesta;
        }




        [HttpPost]

        public async Task<ActionResult<Productos>> PostAgregar(Productos productos)
        {
            try
            {
                context.Add(productos);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpGet("{id}")]

        public async Task<ActionResult<Productos>> GetBuscarPorId(int id)
        {

            var productos = await context.Productos.

                Where(prop => prop.Id == id).
                Include(p => p.Proveedores).
                FirstOrDefaultAsync() ;

            return productos;


        }


        [HttpDelete("{id}")]
        public ActionResult DeleteBorrar (int id)
        {
            var producto = context.Productos.Where(x => x.Id == id).FirstOrDefault();

            if (producto == null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }

            try
            {
                context.Productos.Remove(producto);
                context.SaveChanges();
                return Ok($"El registro de {producto.NombreProducto} ha sido borrado.");
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no pudieron eliminarse por: {e.Message}");
            }
        }

       


        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Productos productos)
        {
            if (id != productos.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var productos1 = context.Productos.Where(e => e.Id == id).FirstOrDefault();

            var proveedores = context.Proveedores.Where(m => m.Id == id).FirstOrDefaultAsync();

            if (productos1 == null)
            {
                return NotFound("No existe la especialidad a modificar");
            }

            productos1.NombreProducto = productos.NombreProducto;

            try
            {
                
                context.Productos.Update(productos1);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }
        }

    }
}