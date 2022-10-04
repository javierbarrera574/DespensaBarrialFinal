
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{

    [Index(nameof(NombreProducto), IsUnique = true)]

    public class Productos : EntityBase
    {


        [Required]
        [MaxLength(30, ErrorMessage = "El nombre del producto no debe superar los 30 caracteres")]
        public string NombreProducto { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "La descripcion no debe superar los 10 caracteres")]
        public string DescripcionProducto { get; set; }

        public DateTime? FechaVencimientoProducto { get; set; }


        [Required]
        [MaxLength(3, ErrorMessage = "El Precio no debe superar el limite estipulado")]
        public decimal PrecioProducto { get; set; }

        public List<Proveedores> Proveedores { get; set; }


        public List<Categorias> Categorias { get; set; }

        [Required(ErrorMessage = "El producto en el deposito es obligatotio")]

        public int DepositoId { get; set; }
        public Deposito ProductoDeposito { get; set; }

    }
}