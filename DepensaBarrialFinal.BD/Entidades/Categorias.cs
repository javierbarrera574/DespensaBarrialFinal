using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Entidades
{
    public class Categorias
    {
        [Key]
        public int IdCategorias { get; set; }
        public TipoCategorias TipoCategoria { get; set; }
    }

    public enum TipoCategorias
    {
        BebidasAlcoholicas = 1,

        Lacteos = 2,

        Azucares = 3,
    }
}