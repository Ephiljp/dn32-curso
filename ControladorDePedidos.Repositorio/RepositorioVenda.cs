using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioVenda : RepositorioGenerico<Venda>
    {
        


            
        
        public List<Venda> Buscar(DateTime? termoDe,DateTime? termoAte)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Venda>().Where(x => DbFunctions.TruncateTime(x.DataDeCadastro) >= termoDe && DbFunctions.TruncateTime(x.DataDeCadastro) <= termoAte).ToList();
            return lista;
        }

        public override void Excluir(Venda item)
        {
            try
            {
                contexto.Set<ItemDaVenda>().RemoveRange(item.ItensDaVenda);
                var original = contexto.Set<Venda>().Find(item.Codigo);
                contexto.Set<Venda>().Remove(original);
                contexto.SaveChanges();

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {

                MessageBox.Show("Não é possivel excluir pois há itens associados");
            }
        }
    }
}
