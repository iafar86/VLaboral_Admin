using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboral_admin.Models
{
    public class TipoDeContrato
    {
        public int Id { get; set; }
        public string NombreTipoDeContrato { get; set; }
        public string DescripcionTipoDeContrato { get; set; }

        //Quique: Relacion Muchos a Muchos con Empleador
        public virtual ICollection<Empleador> Empleadores { get; set; }
    }
}