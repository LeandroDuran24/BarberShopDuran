using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class FacturaBLL
    {

        public static Facturas Guardar(Facturas nuevo)
        {
            Facturas retorno = null;
            using (var conn = new Repositorio<Facturas>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Facturas Buscar(Expression<Func<Facturas, bool>> tipo)
        {
            Facturas Result = null;
            using (var repositorio = new Repositorio<Facturas>())
            {
                Result = repositorio.Buscar(tipo);
                if (Result != null)
                    Result.ServicioList.Count();

            }
            return Result;
        }



        public static bool Mofidicar(Facturas criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<Facturas>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(Facturas existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Facturas>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }

        public static List<Facturas> GetList(Expression<Func<Facturas, bool>> criterio)
        {
            List<Facturas> retorno = null;
            using (var conn = new Repositorio<Facturas>())
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

        public static List<Facturas> GetListTodo()
        {
            List<Facturas> retorno = null;
            using (var conn = new Repositorio<Facturas>())
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
