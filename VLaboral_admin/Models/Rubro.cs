using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboral_admin.Models
{
    public class Rubro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //relacion 1 a muchos(muchos)
        public virtual ICollection<SubRubro> SubRubros { get; set; }

    }

    public class SubRubro
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        //Relacion 1 a muchos(1)
        public int RubroId { get; set; }
        public virtual Rubro Rubro { get; set; }

        //iafar: relacion muchos a muchos con empleados
        public virtual ICollection<Empleado> Empleados { get; set; }

        //iafar: relacion muchos a muchos con empleadores
        public virtual ICollection<Empleador> Empleadores { get; set; }
        
        //Quique: Relacion muchos a muchos con Puesto
        public virtual ICollection<Puesto> Puestos { get; set; }
        
    }
}