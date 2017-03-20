﻿using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioGenerico<T> where T : ClasseBase
    {
        protected Contexto contexto;

        public RepositorioGenerico()
        {
            contexto = new Contexto();

        }

        public virtual void Adicione(T item)
        {

            contexto.Entry(item);
            contexto.Set<T>().Add(item);
            contexto.SaveChanges();
        }

        public virtual void Atualize(T item)
        {
            var original = contexto.Set<T>().Find(item.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(item);
            contexto.SaveChanges();


        }

        public virtual List<T> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<T>().ToList();

        }

        public virtual void Excluir(T item)
        {
            contexto = new Contexto();
            var original = contexto.Set<T>().Find(item.Codigo);
            contexto.Set<T>().Remove(original);
            contexto.SaveChanges();
        }
    }
}