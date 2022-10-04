using DespensaBarrialFinal.BD.Datos;
using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.Server.Controllers
{

    [ApiController]
    [Route("api/Proveedores")]

    public class ProveedoresControlador : ControllerBase
    {

        private readonly AplicacionDbContext  context;

        public ProveedoresControlador(AplicacionDbContext contexto)
        {
            this.context = contexto;

        }

        [HttpGet]

        public async Task<ActionResult<List<Proveedores>>> Get()
        {

            var respuesta =  await context.Proveedores.ToListAsync();
            return respuesta;
                
        }


        [HttpPost]
        public async Task<ActionResult<int>> Post(Proveedores proveedores)
        {
            try
            {
                context.Proveedores.Add(proveedores);
                await context.SaveChangesAsync();
                return proveedores.Id;
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id)
        {
            var proveedoresDB = await context.Proveedores.
                AsTracking().
                FirstOrDefaultAsync(a => a.Id == id);

            if (proveedoresDB is null)
            {
                return NotFound();
            }

          
            await context.SaveChangesAsync();
            return Ok();
        }



        [HttpDelete("{id}")]

        public ActionResult PostBorrar(int id)
        {
            var Proveedor = 
                
                context.Proveedores.
                FirstOrDefaultAsync(prop => prop.Id == id);

            if (Proveedor is null)
            {
                return BadRequest($"El registro {id} no fue encontrar encontrado para ser borrado");
            }


            try
            {
                context.Remove(Proveedor);

                context.SaveChangesAsync();

                return Ok();
            }
            catch(Exception error)
            {
                return BadRequest($"El proveedor no pudo eliminarse: {error.Message}");
            }
        }
    }
}