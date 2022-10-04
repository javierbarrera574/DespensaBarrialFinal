using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Administrador:EntityBase
    {
        [Required]
        [MaxLength(15, ErrorMessage = "El Nombre no debe superar los 15 caracteres")]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "El numero telefonico no debe superar los 9 caracteres")]
        public int NumeroTelefono { get; set; }

        public List<Proveedores> Proveedores { get; set; }

    }
}
