using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DespensaBarrialFinal.BD.Entidades
{
    public class Proveedores
    {
        //mapeo flexible--> Para que los nombres de los proveedores empiecen con mayuscula

        [ForeignKey("AdministadorId")]
        public int AdministadorId { get; set; }

        public string NombreP { get; set; }

        public string Nombre
        {

            get
            {
                return NombreP;
            }

            set
            {

                //Esto lo que hace es unir cada de unos los caracteres,
                //que compone el nombre del Proveedor
                NombreP = string.
                    Join(' ', value.
                    Split(' ').
                    Select(x => x[0].
                    ToString().
                    ToUpper() + x.
                    Substring(1).
                    ToLower().
                    ToArray()));
            }
        }


        public string CorreoElectronico { get; set; }

        public int NumeroTelefono { get; set; }

        public HashSet<ProveedorProducto> ProveedorProductos { get; set; }

        public Administrador Administrador { get; set; }

        [Key]
        public int Id_delproveedor { get; set; }
    }
}
