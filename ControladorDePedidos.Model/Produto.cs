using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class Produto
    {

        [Key]

        public int Codigo { get; set; }

        public string Nome { get; set; }

        public virtual Marca Marca { get; set; }

        public decimal ValorDeCompra { get; set; }

        public decimal ValorDeVenda { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public int QuantidadeMinimaEmEstoque { get; set; }

        public int QuantidadeDesejavelEmEstoque { get; set; }

    }
}
