using DespensaBarrialFinal.BD;
using DespensaBarrialFinal.BD.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Controllers
{

    [ApiController]
    [Route("API/Proveedores")]

    public class ProveedoresControlador : ControllerBase
    {

        private readonly ApplicationDbContext  context;

        public ProveedoresControlador(ApplicationDbContext contexto)
        {
            this.context = contexto;

        }


        [HttpGet("MostrarProveedores")]

        public async Task<ActionResult<List<Proveedores>>> Get()
        {

            var respuesta =  await context.Proveedores.ToListAsync();
            return respuesta;
                
        }


        [HttpPost("AgregarProveedores")]
        public async Task<ActionResult> Post(Proveedores proveedores)
        {
            context.Proveedores.Add(proveedores);
            context.Add(proveedores);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]//Actualizar el registro creado anteriormente con post atraves del id
        public async Task<ActionResult> Put(int id)
        {
            var proveedoresDB = await context.Proveedores.
                AsTracking().
                FirstOrDefaultAsync(a => a.Id_delproveedor == id);

            if (proveedoresDB is null)
            {
                return NotFound();
            }

          
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpDelete("BorrarProveedor")]

        public async Task<ActionResult> PostBorrar(int id)
        {
            var Proveedor = 
                await context.Proveedores.
                FirstOrDefaultAsync(prop => prop.Id_delproveedor == id);

            if (Proveedor is null)
            {
                return BadRequest("No existe el proveedor");
            }

            context.Remove(Proveedor);

            await context.SaveChangesAsync();

            return Ok();
        }
    }
}