using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Fornecedor: ClasseBase

    {

        public string Nome { get; set; }

        public string Email { get; set; }

    }
}
