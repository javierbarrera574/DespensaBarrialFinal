
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{

    [Index(nameof(NombreProducto), IsUnique = true)]

    public class Productos
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "El nombre del producto no debe superar los 30 caracteres")]
        public string NombreProducto { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "La descripcion no debe superar los 10 caracteres")]
        public string DescripcionProducto { get; set; }

        public string FechaVencimientoProducto { get; set; }


        [Required]
        [MaxLength(3, ErrorMessage = "El Precio no debe superar el limite estipulado")]

        public string PrecioProducto { get; set; }

        public List<Proveedores> Proveedores { get; set; }

        public int CategoriaId { get; set; }

        public Categorias Categoria { get; set; }

    }
}