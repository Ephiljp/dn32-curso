using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioPadrao
    {
        Contexto contexto;

        public RepositorioPadrao()
        {
           contexto = new Contexto();

        }
        public void Adicione(Marca marca)
        {
            
            contexto.Entry(marca);
            contexto.Set<Marca>().Add(marca);
            contexto.SaveChanges();
        }
        public void Atulize(Marca marca)
        {
            var original = contexto.Set<Marca>().Find(marca.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(marca);
            contexto.SaveChanges();


        }

        public List<Marca> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<Marca>().ToList();

        }

        public void Excluir(Marca marca)
        {
            var original = contexto.Set<Marca>().Find(marca.Codigo);
            contexto.Set<Marca>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
