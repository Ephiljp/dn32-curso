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

        public DateTime DataDeCadastro { get; set; }

        public DateTime DataDaEfetivacao { get; set; }

        public DateTime DataDoRecebimento { get; set; }

        public int QuantidadeDeProdutos { get; set; }

        public List<ItemDaCompra> ItensDaCompra { get; set; }

        public eStatusDaCompra Status { get; set; }

    }
}
