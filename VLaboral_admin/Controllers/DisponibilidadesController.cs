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
    public class DisponibilidadesController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Disponibilidades
        public IQueryable<Disponibilidad> GetDisponibilidads()
        {
            return db.Disponibilidades;
        }

        // GET: api/Disponibilidades/5
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult GetDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidades.Find(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return Ok(disponibilidad);
        }

        // PUT: api/Disponibilidades/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDisponibilidad(int id, Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != disponibilidad.Id)
            {
                return BadRequest();
            }

            db.Entry(disponibilidad).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisponibilidadExists(id))
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

        // POST: api/Disponibilidades
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult PostDisponibilidad(Disponibilidad disponibilidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Disponibilidades.Add(disponibilidad);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = disponibilidad.Id }, disponibilidad);
        }

        // DELETE: api/Disponibilidades/5
        [ResponseType(typeof(Disponibilidad))]
        public IHttpActionResult DeleteDisponibilidad(int id)
        {
            Disponibilidad disponibilidad = db.Disponibilidades.Find(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            db.Disponibilidades.Remove(disponibilidad);
            db.SaveChanges();

            return Ok(disponibilidad);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DisponibilidadExists(int id)
        {
            return db.Disponibilidades.Count(e => e.Id == id) > 0;
        }
    }
}