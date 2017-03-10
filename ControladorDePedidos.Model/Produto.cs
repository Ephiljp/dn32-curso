using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Produto
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public Marca Marca { get; set; }

        public decimal ValorDeCompra { get; set; }

        public decimal ValorDeVenda { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public int QuantidadeMinimaEmEstoque { get; set; }

        public int QuantidadeDesejavelEmEstoque { get; set; }

    }
}
