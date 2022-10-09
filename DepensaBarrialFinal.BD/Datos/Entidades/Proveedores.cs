
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Proveedores
    {
        //mapeo flexible--> Para que los nombres de los proveedores empiecen con mayuscula


        public int Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "El Nombre no debe superar los 20 caracteres")]
        public string Nombre { get; set; }
      

        [Required]
        [MaxLength(12, ErrorMessage = "El correo electronico es indispensable")]
        public string CorreoElectronico { get; set; }


        [Required]
        [MaxLength(9, ErrorMessage = "El Telefono no debe superar los 9 caracteres")]

        public string NumeroTelefono { get; set; }

        public int AdministradorId { get; set; }

        public Administrador Administrador { get; set; }

    }
}