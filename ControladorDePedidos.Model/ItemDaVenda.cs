using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Model
{
    public class ItemDaVenda : ClasseBase
    {

        public virtual Produto Produto { get; set; }

        public virtual Venda Venda { get; set; }

        public int Quantidade { get; set; }

        public decimal Valor { get; set; }

      

        [NotMapped]
        public string ClienteNome
        {
            get
            {
                try
                {
                    return Venda.Cliente.Nome;
                }
                catch (Exception)
                {

                    return "Avulso";
                }
                    
                   
               
            }

        }

        [NotMapped]
        public decimal CodigoVenda
        {
            get
            {
                return Venda.Codigo;
            }

        }


        [NotMapped]
        public decimal ValorTotal
        {
            get
            {
                return Quantidade * Valor;
            }

        }

        [NotMapped]
        public string Nome
        {
            get
            {
                return Produto.Nome;
            }
        }

        [NotMapped]
        public DateTime DataDeCadastro
        {
            get
            {
                return Venda.DataDeCadastro;
            }
        }
    }
}
