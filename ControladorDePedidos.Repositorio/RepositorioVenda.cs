using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioVenda : RepositorioGenerico<Venda>
    {
        


            
        
        public List<Venda> Buscar(DateTime? termoDe,DateTime? termoAte)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Venda>().Where(x => DbFunctions.TruncateTime(x.DataDeCadastro) >= termoDe && DbFunctions.TruncateTime(x.DataDeCadastro) <= termoAte).ToList();
            return lista;
        }
    }
}
