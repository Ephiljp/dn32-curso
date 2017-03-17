using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioItemDaCompra
    {
        Contexto contexto;

        public RepositorioItemDaCompra()
        {
           contexto = new Contexto();

        }
        public void Adicione(ItemDaCompra itemDaCompra)
        {
            var compraOriginal = contexto.Set<Compra>().Find(itemDaCompra.Compra.Codigo);
            itemDaCompra.Compra = compraOriginal;

            var produtoOriginal = contexto.Set<Produto>().Find(itemDaCompra.Produto.Codigo);
            itemDaCompra.Produto = produtoOriginal;
                       
            contexto.Set<ItemDaCompra>().Add(itemDaCompra);
            contexto.SaveChanges();

        }
        public void Atualize(ItemDaCompra itemDaCompra)
        {
            var original = contexto.Set<ItemDaCompra>().Find(itemDaCompra.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(itemDaCompra);
            contexto.SaveChanges();


        }

        public List<ItemDaCompra> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<ItemDaCompra>().ToList();

        }

        public List<ItemDaCompra> Liste(int CodigoDaCompra)
        {
            contexto = new Contexto();
            return contexto.Set<ItemDaCompra>().Where(x => x.Compra.Codigo == CodigoDaCompra) .ToList();

        }

        public void Excluir(ItemDaCompra itemDaCompra)
        {
            contexto = new Contexto();
            var original = contexto.Set<ItemDaCompra>().Find(itemDaCompra.Codigo);
            contexto.Set<ItemDaCompra>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
