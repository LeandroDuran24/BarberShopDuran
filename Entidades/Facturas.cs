using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public int ServicioId { get; set; }
        public string NombreCliente { get; set; }
        public double DescuentoPorciento { get; set; }
        public string Comentario { get; set; }
        public int Impuesto { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoPago { get; set; }
        public double Total { get; set; }
        public double SubTotal { get; set; }


        public virtual List<TipoServicios> ServicioList { get; set; }
       
        public Facturas()
        {
            this.ServicioList = new List<TipoServicios>();
           
        }
    }
}
