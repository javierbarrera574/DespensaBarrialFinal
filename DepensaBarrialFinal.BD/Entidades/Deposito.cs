using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DespensaBarrialFinal.BD.Entidades
{
    public class Deposito
    {
        [Key]
        public int Id { get; set; }
        public int UnidadMinima { get; set; }

        public List<Productos> ProductosEnDeposito { get; set; }

        public Empleado EmpleadoDeposito { get; set; }


    }
}
