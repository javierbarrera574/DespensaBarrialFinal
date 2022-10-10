
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Proveedor
    {

        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
      

        [Required]
        public string CorreoElectronico { get; set; }


        [Required]

        public string NumeroTelefono { get; set; }


        //[Required]
        //public int AdministradorId { get; set; }

        //public Administrador Administrador { get; set; }

    }
}