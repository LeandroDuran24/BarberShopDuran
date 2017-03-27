using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Peluqueros
    {
        [Key]
        public int PeluqueroId { get; set; }
        public string Nombre { get; set; }
        public DateTime HoraOcupadoHasta { get; set; }
    }
}
