using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Usuario: ClasseBase
    {
      

        public string Nome { get; set; }

        public bool Administrador { get; set; }

        public bool Clientes { get; set; }

        public bool Produtos { get; set; }

        public bool Vendas { get; set; }

        public bool Fornecedores { get; set; }

        public bool Compras { get; set; }

    }
}
