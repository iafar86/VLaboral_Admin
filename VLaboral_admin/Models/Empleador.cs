using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace VLaboral_admin.Models
{
    public class Empleador
    {
        public int Id { get; set; }
        public string Cuit { get; set; }
        public string Rsocial { get; set; }
        public string Dir { get; set; }
        public string Tel { get; set; }
        public string Mail { get; set; }
        public string Descripcion { get; set; }

        //iafar: falta relacion muchos a muchos con SubRubros
       public virtual ICollection<SubRubro> Subrubros { get; set; }
       
        //Quique: Relacion Muchos a Muchos con TipoDeContrato
       public virtual ICollection<TipoDeContrato> TipoDeContratos { get; set; } 

        //Quique: Relacion muchos a muchos con Profesion
       public virtual ICollection<Profesion> Profesiones { get; set; }

    }

}