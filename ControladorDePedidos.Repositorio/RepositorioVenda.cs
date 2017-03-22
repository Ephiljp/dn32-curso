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


        public override void Adicione(Venda item)
        {
            if (item.Cliente != null)
            {
                item.Cliente = contexto.Set<Cliente>().Find(item.Cliente.Codigo);
            }


            base.Adicione(item);
        }


        public override void Atualize(Venda item)
        {
            var original = contexto.Set<Venda>().Find(item.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(item);

            if (item.Cliente != null)
            {
                original.Cliente = contexto.Set<Cliente>().Find(item.Cliente.Codigo);
                contexto.Cliente.Attach(original.Cliente);
            }



            contexto.SaveChanges();

        }


        public List<Venda> Buscar(DateTime? termoDe, DateTime? termoAte)
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
