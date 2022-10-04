using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Categorias:EntityBase
    {

        [Required]

        public string TipoCategoria { get; set; }


        [Required]

        public string CodigoCategoria { get; set; }

        public Productos Producto { get; set; }

    }
}