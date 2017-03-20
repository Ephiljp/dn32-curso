using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioProduto : RepositorioGenerico<Produto>
    {
       

        public List<Produto> Buscar(string termoDaBusca )
        {
            contexto = new Contexto();
            var lista = contexto.Set<Produto>().Where(x => x.Nome.Contains(termoDaBusca)).ToList();
            return lista;
        }

        public List<Produto> ObetnhaProdutosComEstoqueBaixo()
        {
            contexto = new Contexto();

            var lista = contexto.Set<Produto>().Where(x => x.QuantidadeEmEstoque < x.QuantidadeDesejavelEmEstoque  ).ToList();
            return lista;
        }

        public Produto Buscar(int Codigo)
        {
            contexto = new Contexto();
            return contexto.Set<Produto>().FirstOrDefault(x => x.Codigo == Codigo);
            
        }

    }
}
