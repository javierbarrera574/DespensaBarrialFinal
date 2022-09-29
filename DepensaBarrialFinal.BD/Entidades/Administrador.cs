using System;
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Entidades
{
    public class Administrador
    {
        [Key]

        public int IdAdministrador { get; set; }

        public string Nombre { get; set; }

        public HashSet<Proveedores> ProveedoresAdministrador { get; set; }

        public virtual Empleado UnEmpleado { get; set; }


    }
}
