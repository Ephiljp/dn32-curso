﻿using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioCompra : RepositorioGenerico <Compra>
    {
        

        public List<Compra> Buscar(DateTime? termoDe,DateTime? termoAte)
        {
            contexto = new Contexto();
            var lista = contexto.Set<Compra>().Where(x => DbFunctions.TruncateTime(x.DataDeCadastro) >= termoDe && DbFunctions.TruncateTime(x.DataDeCadastro) <= termoAte).ToList();
            return lista;
        }
    }
}
