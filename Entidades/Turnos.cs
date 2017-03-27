using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Turnos
    {
        [Key]
        public int TurnosId { get; set; }
        public string NombreCliente { get; set; }
        public string NombrePeluquero { get; set; }
        public DateTime FechaDesde{ get; set; }
        public DateTime FechaHasta { get; set; }
        public int ClienteId { get; set; }
        public int PeluqueroId { get; set; }
     
    }
}
