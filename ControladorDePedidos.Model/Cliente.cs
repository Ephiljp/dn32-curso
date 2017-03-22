using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Cliente: ClasseBase
    {
    

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public List<Venda> Vendas { get; set; }


    }
}
