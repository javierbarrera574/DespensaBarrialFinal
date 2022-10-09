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

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, [FromBody] Proveedores proveedores)
        {


            if (id != proveedores.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var registro = context.Proveedores.Where(e => e.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound("No existe la especialidad a modificar");
            }

            registro.Nombre = proveedores.Nombre;
            registro.CorreoElectronico = proveedores.CorreoElectronico;
            registro.NumeroTelefono = proveedores.NumeroTelefono;


            try
            {
              
                context.Proveedores.Update(registro);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Los datos no han sido actualizados por: {e.Message}");
            }

        }



        [HttpDelete("{id}")]

        public ActionResult PostBorrar(int id)
        {
            var Proveedor = context.Proveedores.Where(x => x.Id == id).FirstOrDefault();
             

            if (Proveedor is null)
            {
                return BadRequest($"El registro {id} no fue encontrar encontrado para ser borrado");
            }


            try
            {
                context.Remove(Proveedor);

                context.SaveChanges();

                return Ok();
            }
            catch(Exception error)
            {
                return BadRequest($"El proveedor no pudo eliminarse: {error.Message}");
            }
        }
    }
}