﻿using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioItemDaCompra : RepositorioGenerico <ItemDaCompra>
    {
        

        public RepositorioItemDaCompra()
        {
           contexto = new Contexto();

        }
        public override void Adicione(ItemDaCompra itemDaCompra)
        {
            var compraOriginal = contexto.Set<Compra>().Find(itemDaCompra.Compra.Codigo);
            itemDaCompra.Compra = compraOriginal;

            var produtoOriginal = contexto.Set<Produto>().Find(itemDaCompra.Produto.Codigo);
            itemDaCompra.Produto = produtoOriginal;
                       
            contexto.Set<ItemDaCompra>().Add(itemDaCompra);
            contexto.SaveChanges();

        }
      
        
        public List<ItemDaCompra> Liste(int CodigoDaCompra)
        {
            contexto = new Contexto();
            return contexto.Set<ItemDaCompra>().Where(x => x.Compra.Codigo == CodigoDaCompra) .ToList();

        }

     
    }
}
