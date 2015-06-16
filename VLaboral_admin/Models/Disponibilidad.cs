using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboral_admin.Models
{
    public class Disponibilidad
    {
        /*Tipo de oferta refiere a si es part-time, full-time, etc*/
        public int Id { get; set; }
        public string NombreDisponibilidad { get; set; }
        public string DescripcionDisponibilidad { get; set; }
    }
}