namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Deposito : EntityBase
    {

        public int Unidad_minima { get; set; }

        public List<Productos>  Productos { get; set; }

    }
}
