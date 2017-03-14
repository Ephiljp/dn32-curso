using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCompra
    {
        Contexto contexto;

        public RepositorioCompra()
        {
           contexto = new Contexto();

        }
        public void Adicione(Compra compra)
        {
            
            contexto.Entry(compra);
            contexto.Set<Compra>().Add(compra);
            contexto.SaveChanges();
        }
        public void Atualize(Compra compra)
        {
            var original = contexto.Set<Compra>().Find(compra.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(compra);
            contexto.SaveChanges();


        }

        public List<Compra> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<Compra>().ToList();

        }

        public void Excluir(Compra compra)
        {
            contexto = new Contexto();
            var original = contexto.Set<Compra>().Find(compra.Codigo);
            contexto.Set<Compra>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
