using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DAL;
using Entidades;

namespace BLL
{
    public class ClienteBLL
    {
        public static Clientes Guardar(Clientes nuevo)
        {
            Clientes retorno = null;
            using (var conn = new Repositorio<Clientes>())
            {
                retorno = conn.Guardar(nuevo);
            }
            return retorno;
        }

        public static Clientes Buscar(Expression<Func<Clientes, bool>> tipo)
        {
            Clientes Result = null;
            using (var repositorio = new Repositorio<Clientes>())
            {
                Result = repositorio.Buscar(tipo);



            }
            return Result;
        }



        public static bool Mofidicar(Clientes criterio)
        {
            bool mod = false;
            using (var db = new Repositorio<Clientes>())
            {
                mod = db.Modificar(criterio);
            }

            return mod;

        }

        public static bool Eliminar(Clientes existente)
        {
            bool eliminado = false;
            using (var repositorio = new Repositorio<Clientes>())
            {
                eliminado = repositorio.Eliminar(existente);
            }

            return eliminado;

        }

        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> retorno = null;
            using (var conn = new Repositorio<Clientes>())
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

        public static List<Clientes> GetListTodo()
        {
            List<Clientes> retorno = null;
            using (var conn = new Repositorio<Clientes>())
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
