using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespensaBarrialFinal.BD.Entidades
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        public string NombreEmpleado { get; set; }

        public ulong EdadEmpleado { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string Domicilio { get; set; }

        public ulong NumeroTelefono { get; set; }

        //[ForeignKey("AdministradorId")]

        //[ForeignKey("Administrador")]

        public int AdministadorId { get; set; }

        [ForeignKey(nameof(AdministadorId))]

        public virtual Administrador Administrador { get; set; }

    }
}