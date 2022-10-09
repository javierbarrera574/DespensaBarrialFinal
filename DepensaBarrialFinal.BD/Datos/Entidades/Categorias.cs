using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Categorias
    {

        public int Id { get; set; }

        [Required]

        public string TipoCategoria { get; set; }


        [Required]

        public string CodigoCategoria { get; set; }

        public List<Productos> Productos { get; set; }

    }
}