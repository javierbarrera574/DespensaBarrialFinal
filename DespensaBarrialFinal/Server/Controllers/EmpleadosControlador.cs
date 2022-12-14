using DespensaBarrialFinal.BD.Datos;
using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.Server.Controllers
{

    [ApiController]
    [Route("api/Empleados")]
    public class EmpleadosControlador:ControllerBase
    {


        private readonly AplicacionDbContext context;

        public EmpleadosControlador(AplicacionDbContext context)
        {
            this.context = context;
        }

        [HttpGet]//esta bien
        public async Task<ActionResult<List<Empleado>>> Get()
        {

            var registro = await context.Empleados.ToListAsync();

            return registro;

        }


        #region
        //[HttpGet("id:int")]

        //public async Task<ActionResult<Empleado>> GetBuscar(int id)
        //{

        //    var empleado = await context.Empleado.
        //        Where(x => x.Id == id).
        //        Include(p => p.NombreEmpleado).
        //        Include(x=>x.EdadEmpleado).
        //        Include(f=>f.FechaNacimiento).
        //        Include(d=>d.Domicilio).
        //        Include(t=>t.NumeroTelefono).
        //        Include(d=>d.DNI).
        //        FirstOrDefaultAsync();

        //    if (empleado is null)
        //    {
        //        return NotFound($"No se encontro el administrador de Id: {id}");
        //    }

        //    return empleado;


        //}

        #endregion


        [HttpPost]

        public async Task<ActionResult<int>> post(Empleado empleado)
        {
            try
            {

                context.Add(empleado);
                await context.SaveChangesAsync();
                return empleado.Id;

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("id:int")]

        public async Task<ActionResult<Empleado>> GetBuscar(int id)
        {

            var empleado = await context.Empleados.
                Where(x => x.Id == id).
                FirstOrDefaultAsync();

            if (empleado is null)
            {
                return NotFound($"No se encontro el empleado de Id: {id}");
            }

            return empleado;
        }


        [HttpPut("id:int")]

        public ActionResult PutActualizar(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Empleados.Where(x => x.Id == id).FirstOrDefault();

            //como la categoria esta en la base de datos dentro de registro
            //y categoria es como quiero que quede despues de hacer la modificacion

            if (registro is null)
            {
                return NotFound("No existe el empleado a modificar");
            }


            //actualizacion de los objetos que hay en la base de datos con los que hay en el cuerpo(body)

            registro.edad = empleado.edad;
            registro.edad = empleado.edad;
           
          


            try
            {

                context.Empleados.Update(registro);//si mando aca dentro de update, al objeto categorias, no va a haber conexion con la base de datos
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo actualizar el empleado, por el siguiente error: {e.Message}");
            }

        }

        [HttpDelete]

        public ActionResult delete(int id)
        {
            var registro = context.Empleados.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El registro: {registro.nombre} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El registro no pudo eliminarse por: {e.Message}");

            }
        }

    }
}