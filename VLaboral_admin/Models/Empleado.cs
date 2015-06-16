using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VLaboral_admin.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Cuil { get; set; }
        public String NombreApellido { get; set; }
        public DateTime FecNacimiento { get; set; }
        public String Email { get; set; }
        public String Direccion { get; set; }
        public int Telefono { get; set; }
        //iafar: deberiamos poner la ocupacion aqui o en el curriculum?


        //Relacion 1 a 1
        //public int CurriculumId { get; set; }
        //public virtual Curriculum Curriculum { get; set; }

        //iafar:Relacion 1 a muchos(1)
        //public int UbicacionActualId { get; set; }
        //public virtual UbicacionActual UbicacionActual { get; set; }
        
        //iafar:Relacion 1 a muchos(1)
        //public int UbicacionOrigenId { get; set; }
        //public virtual UbicacionOrigen UbicacionOrigen { get; set; }

        //Quique: Relacion Muchos a Muchos con Puesto
        public virtual ICollection<Puesto> puestos { get; set; }


    }

    public class Curriculum
    {   
        
        public int Id { get; set; }
        public String Habilidades { get; set; }
        public String Descripcion { get; set; }

        //iafar: relacion muchos a muchos con rubro
        public virtual ICollection<SubRubro> SubRubros { get; set; }



    }

}