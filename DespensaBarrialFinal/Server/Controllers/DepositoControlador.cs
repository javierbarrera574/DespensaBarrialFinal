using DespensaBarrialFinal.BD.Datos;
using DespensaBarrialFinal.BD.Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.Server.Controllers
{
    public class DepositoControlador:ControllerBase
    {

        private readonly AplicacionDbContext context;

        public DepositoControlador(AplicacionDbContext contexto)
        {
            this.context = contexto;

        }



        [HttpGet]
        public async Task<ActionResult<List<Deposito>>> Get()
        {
            var respuesta = await context.Deposito.ToListAsync();

            return respuesta;
        }


        [HttpPost]

        public async Task<ActionResult<int>> post(Deposito deposito)
        {
            try
            {
                context.Deposito.Add(deposito);
                await context.SaveChangesAsync();
                return deposito.Id;//Es devuelto con el id asignado

            }
            catch (Exception p)
            {
                return BadRequest(p.Message);
            }
        }

        [HttpPut("id:int")]

        public ActionResult PutActualizar(int id, [FromBody] Deposito deposito)
        {
            if (id != deposito.Id)
            {
                return BadRequest("No se encontro el registro");
            }


            var registro = context.Deposito.Where(x => x.Id == id).FirstOrDefault();

            //como la categoria esta en la base de datos dentro de registro
            //y categoria es como quiero que quede despues de hacer la modificacion

            if (registro is null)
            {
                return NotFound("No existe la categoria a modificar");
            }


            //actualizacion de los objetos que hay en la base de datos con los que hay en el cuerpo(body)

            registro.CodigoEstante = deposito.CodigoEstante;
            registro.CategoriaEnEstante = deposito.CategoriaEnEstante;
            registro.CantidadEnEstante = deposito.CantidadEnEstante;


            try
            {

                context.Deposito.Update(registro);//si mando aca dentro de update, al objeto categorias, no va a haber conexion con la base de datos
                context.SaveChanges();
                return Ok();

            }
            catch (Exception e)
            {
                return BadRequest
                    ($"Los datos no han podido ser actualizados, por el siguiente error: {e.Message}");
            }
        }



        [HttpDelete("id:int")]


        public ActionResult Borrar(int id)
        {

            var registro = context.Deposito.Where(x => x.Id == id).FirstOrDefault();

            if (registro is null)
            {
                return NotFound($"El registro {id} no fue encontrado");
            }


            try
            {
                context.Remove(registro);
                context.SaveChanges();
                return Ok($"El registro: {registro.CodigoEstante} ha sido eliminado");
            }
            catch (Exception e)
            {

                return BadRequest($"El registro no pudo eliminarse por: {e.Message}");

            }

        }
    }
}