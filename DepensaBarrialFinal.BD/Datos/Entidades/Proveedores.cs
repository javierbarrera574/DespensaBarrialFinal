
using System.ComponentModel.DataAnnotations;

namespace DespensaBarrialFinal.BD.Datos.Entidades
{
    public class Proveedores:EntityBase
    {
        //mapeo flexible--> Para que los nombres de los proveedores empiecen con mayuscula

      

        public string _nombre;//para formatear es mejor usar una variable en vez de una propiedad

        [Required]
        [MaxLength(20, ErrorMessage = "El Nombre no debe superar los 20 caracteres")]
        public string Nombre
        {

            get
            {
                return _nombre;
            }

            set
            {

                //Esto lo que hace es unir cada de unos los caracteres,
                //que compone el nombre del Proveedor


                _nombre = string.Join(' ',
                     value.Split(' ')
                     .Select(x => x[0].
                     ToString().ToUpper() + x.Substring(1).ToLower()).ToArray());
            }
        }

        [Required]
        [MaxLength(12, ErrorMessage = "El correo electronico es indispensable")]
        public string CorreoElectronico { get; set; }


        [Required]
        [MaxLength(9, ErrorMessage = "El Telefono no debe superar los 9 caracteres")]

        public int NumeroTelefono { get; set; }



        [Required(ErrorMessage ="El administrador es necesario")]
        public int AdministadorId { get; set; }
        public Administrador Administrador { get; set; }

     
    }
}