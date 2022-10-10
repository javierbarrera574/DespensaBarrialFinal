
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Empleado
    {

        public int Id { get; set; }

        [Required]
        public string nombre { get; set; }

        [Required]
        public string apellido { get; set; }

        [Required]

        public string edad { get; set; }
    
    }
}