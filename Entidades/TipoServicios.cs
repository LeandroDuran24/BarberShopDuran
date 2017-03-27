using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class TipoServicios
    {
        [Key]
        public int ServicioId { get; set; }
        public string Nombre { get; set; } 
        public int Costo { get; set; }

        public virtual List<Facturas> FacturaList { get; set; }

        public TipoServicios()
        {
            this.FacturaList = new List<Facturas>();
        }
    }
}
