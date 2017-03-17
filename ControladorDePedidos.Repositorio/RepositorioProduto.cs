using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioProduto
    {
        Contexto contexto;

        public RepositorioProduto()
        {
           contexto = new Contexto();

        }
        public void Adicione(Produto produto)
        {
            var marcaOriginal = contexto.Set<Marca>().Find(produto.Marca.Codigo);
            produto.Marca = marcaOriginal;
           
            contexto.Set<Produto>().Add(produto);
            contexto.SaveChanges();
        }
        public void Atualize(Produto produto)
        {
            var marcaOriginal = contexto.Set<Marca>().Find(produto.Marca.Codigo);


            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(produto);
            original.Marca = marcaOriginal;
            contexto.SaveChanges();


        }

        public List<Produto> Liste()
        {
            contexto = new Contexto();
            var lista =  contexto.Set<Produto>().ToList();
            return lista;
        }

        public void Excluir(Produto produto)
        {
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Set<Produto>().Remove(original);
            contexto.SaveChanges();
        }

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
    }
}
