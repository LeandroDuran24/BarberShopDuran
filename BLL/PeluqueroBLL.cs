using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class PeluqueroBLL
    {

        public static Peluqueros Guardar(Peluqueros nuevo)
        {
            Peluqueros retorno = null;
            using (var conn = new Repositorio<Peluqueros>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Peluqueros Buscar(Expression<Func<Peluqueros, bool>> tipo)
        {
            Peluqueros Result = null;
            using (var repositorio = new Repositorio<Peluqueros>())
            {
                Result = repositorio.Buscar(tipo);

            }
            return Result;
        }


        public static bool Mofidicar(Peluqueros criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<Peluqueros>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(Peluqueros existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Peluqueros>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }

        public static List<Peluqueros> GetList(Expression<Func<Peluqueros, bool>> criterio)
        {
            List<Peluqueros> retorno = null;
            using (var conn = new Repositorio<Peluqueros>())
            {
                try
                {
                    retorno = conn.GetList(criterio).ToList();
                }
                catch (Exception)
                {

                    throw;
                }
                return retorno;
            }

        }

        public static List<Peluqueros> GetListTodo()
        {
            List<Peluqueros> retorno = null;
            using (var conn = new Repositorio<Peluqueros>())
            {
                try
                {
                    retorno = conn.GetListTodo().ToList();

                }
                catch (Exception)
                {

                    throw;
                }
                return retorno;
            }

        }
    }
}
