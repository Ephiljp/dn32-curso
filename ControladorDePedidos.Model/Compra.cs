using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Compra
    {
        [Key]

        public int Codigo { get; set; }
    }
}
