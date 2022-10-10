
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{

    [Index(nameof(NombreProducto), IsUnique = true)]

    public class Productos
    {

        public int Id { get; set; }

        [Required]
        public string NombreProducto { get; set; }

        [Required]
        public string DescripcionProducto { get; set; }

        public string FechaVencimiento { get; set; }


        [Required]

        public string PrecioProducto { get; set; }

        public List<Proveedores> Proveedores { get; set; }

        public int? CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

    }
}