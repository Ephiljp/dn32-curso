using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioUsuario
    {
        Contexto contexto;

        public RepositorioUsuario()
        {
           contexto = new Contexto();

        }
        public void Adicione(Usuario usuario)
        {
            
            contexto.Entry(usuario);
            contexto.Set<Usuario>().Add(usuario);
            contexto.SaveChanges();
        }
        public void Atualize(Usuario usuario)
        {
            var original = contexto.Set<Usuario>().Find(usuario.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(usuario);
            contexto.SaveChanges();


        }

        public List<Usuario> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<Usuario>().ToList();

        }

        public void Excluir(Usuario usuario)
        {
            contexto = new Contexto();
            var original = contexto.Set<Usuario>().Find(usuario.Codigo);
            contexto.Set<Usuario>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
