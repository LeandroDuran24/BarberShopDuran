using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
   public class TurnoBLL
    {
        public static bool Guardar(Turnos nuevo)
        {
            bool retorno = false;
            using (var conn = new Repositorio<Turnos>())
            {
                retorno = conn.Guardar(nuevo) != null;
            }
            return retorno;
        }

        public static Turnos Buscar(Expression<Func<Turnos, bool>> tipo)
        {
            Turnos Result = null;
            using (var repositorio = new Repositorio<Turnos>())
            {
                Result = repositorio.Buscar(tipo);


            }
            return Result;
        }



        public static bool Mofidicar(Turnos criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<Turnos>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(Turnos existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Turnos>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }



        public static List<Turnos> GetList(Expression<Func<Turnos, bool>> criterio)
        {
            List<Turnos> retorno = null;
            using (var conn = new Repositorio<Turnos>())
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

        public static List<Turnos> GetListTodo()
        {
            List<Turnos> retorno = null;
            using (var conn = new Repositorio<Turnos>())
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
