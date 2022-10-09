using DespensaBarrialFinal.BD.Datos;
using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace DespensaBarrialFinal.Server.Controllers
{
    public class AdministradorControlador : ControllerBase
    {
        private readonly AplicacionDbContext context;

        public AdministradorControlador(AplicacionDbContext contexto)
        {
            this.context = contexto;
        }

        [HttpGet]//esta bien
        public async Task<ActionResult<List<Administrador>>> Get()
        {
            var respuesta = await context.Administrador.ToListAsync();

            return respuesta;
        }

        [HttpPost]

        public async Task<ActionResult<int>> Post(Administrador administrador)
        {
            try
            {
                context.Add(administrador);
                await context.SaveChangesAsync();
                return administrador.Id;
            }
            catch (Exception e)
            {
                return BadRequest($"No se pudo agregar el administrador por: { e.Message}");
            }
        }


        [HttpPut]

        public ActionResult Put(int id,[FromBody] Administrador administrador)
        {

            if (id != administrador.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Administrador.Where(x => x.Id == id).FirstOrDefault();

            //como la categoria esta en la base de datos dentro de registro
            //y categoria es como quiero que quede despues de hacer la modificacion

            if (registro is null)
            {
                return NotFound("No existe la categoria a modificar");
            }


            //actualizacion de los objetos que hay en la base de datos con los que hay en el cuerpo(body)

            registro.Nombre = administrador.Nombre;
            registro.NumeroTelefono = administrador.NumeroTelefono;


            try
            {

                context.Administrador.Update(registro);//si mando aca dentro de update, al objeto categorias, no va a haber conexion con la base de datos
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest
                    ($"No se pudo actualizar el administrador, por el siguiente error: {e.Message}");
            }
        }

        [HttpDelete]

        public ActionResult Delete(int id)
        {
            var registro = context.Administrador.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El registro: {registro.Nombre} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El administrador no pudo eliminarse por: {e.Message}");

            }
        }

    }
}