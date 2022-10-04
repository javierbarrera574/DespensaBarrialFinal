
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DespensaBarrialFinal.BD.Datos.Entidades
{

    [Index(nameof(DNI), Name = "EmpleadoDNI_UQ", IsUnique = true)]
    public class Empleado:EntityBase
    {
        [Required]
        [MaxLength(25, ErrorMessage = "El nombre no debe superar los 25 caracteres")]
        public string NombreEmpleado { get; set; }

        [Required]
        [MaxLength(2, ErrorMessage = "La edad no debe superar el limite establecido")]

        public int EdadEmpleado { get; set; }

        [Required]
        [MaxLength(12, ErrorMessage = "La fecha no debe superar los 12 caracteres")]

        public DateTime? FechaNacimiento { get; set; }


        [Required]
        [MaxLength(40, ErrorMessage = "La direccion no debe superar los 40 caracteres")]

        public string Domicilio { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "El numero de telefono no debe superar los 9 caracteres")]
        public int NumeroTelefono { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "El no debe superar los 9 digitos")]
        public int DNI  { get; set; }

    }
}