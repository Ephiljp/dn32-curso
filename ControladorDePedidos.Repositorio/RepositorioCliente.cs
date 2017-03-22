using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCliente : RepositorioGenerico <Cliente>
    {

        public List<Cliente> Buscar(string termoDaBusca)
        {
            contexto = new Contexto();
            return contexto.Set<Cliente>().Where(x => x.Nome.Contains(termoDaBusca)).ToList();
            
        }


    }
}
