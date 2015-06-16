using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using VLaboral_admin.Models;

namespace VLaboral_admin.Controllers
{
    public class EmpleadoresController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Empleadores
        public IHttpActionResult GetEmpleadores()
        {
            try
            {
                var listEmpleadores = db.Empleadores.ToList();
                if (listEmpleadores == null)
                {
                    return BadRequest("No existen empleadores cargados");
                }
                return Ok(listEmpleadores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }            
        }

        // GET: api/Empleadores/5
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult GetEmpleador(int id)
        {
            Empleador empleador = db.Empleadores.FirstOrDefault();
            if (empleador == null)
            {
                return NotFound();
            }

            return Ok(empleador);
        }

        // PUT: api/Empleadores/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleador(int id, Empleador empleador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleador.Id)
            {
                return BadRequest();
            }

            db.Entry(empleador).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Empleadores
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult PostEmpleador(Empleador empleador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                db.Empleadores.Add(empleador);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        // DELETE: api/Empleadores/5
        [ResponseType(typeof(Empleador))]
        public IHttpActionResult DeleteEmpleador(int id)
        {
            Empleador empleador = db.Empleadores.Find(id);
            if (empleador == null)
            {
                return NotFound();
            }

            db.Empleadores.Remove(empleador);
            db.SaveChanges();

            return Ok(empleador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadorExists(int id)
        {
            return db.Empleadores.Count(e => e.Id == id) > 0;
        }
    }
}