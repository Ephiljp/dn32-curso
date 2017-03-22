using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCompra : RepositorioGenerico<Compra>
    {


        public List<Compra> Buscar(DateTime? termoDe, DateTime? termoAte)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Compra>().Where(x => DbFunctions.TruncateTime(x.DataDeCadastro) >= termoDe && DbFunctions.TruncateTime(x.DataDeCadastro) <= termoAte).ToList();
            return lista;
        }

        public override void Excluir(Compra item)
        {
            try
            {
                contexto.Set<ItemDaCompra>().RemoveRange(item.ItensDaCompra);
                var original = contexto.Set<Compra>().Find(item.Codigo);
                contexto.Set<Compra>().Remove(original);
                contexto.SaveChanges();

            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {

                MessageBox.Show("Não é possivel excluir pois há itens associados");
            }
        }
    }
}
