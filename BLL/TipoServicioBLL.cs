using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
   public class TipoServicioBLL
    {
        public static TipoServicios Guardar(TipoServicios nuevo)
        {
            TipoServicios retorno = null;
            using (var conn = new Repositorio<TipoServicios>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static TipoServicios Buscar(Expression<Func<TipoServicios, bool>> tipo)
        {
            TipoServicios Result = null;
            using (var repositorio = new Repositorio<TipoServicios>())
            {
                Result = repositorio.Buscar(tipo);

            }
            return Result;
        }


        public static bool Mofidicar(TipoServicios criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<TipoServicios>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(TipoServicios existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<TipoServicios>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }

        public static List<TipoServicios> GetList(Expression<Func<TipoServicios, bool>> criterio)
        {
            List<TipoServicios> retorno = null;
            using (var conn = new Repositorio<TipoServicios>())
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

        public static List<TipoServicios> GetListTodo()
        {
            List<TipoServicios> retorno = null;
            using (var conn = new Repositorio<TipoServicios>())
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

        public static TipoServicios Busca(int id)
        {
            TipoServicios ser = new TipoServicios();
            using (var db = new BarberShopDb())
            {
                ser = db.servicio.Find(id);
            }
            return ser;
        }
    }
}
