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
    public class ProfesionesController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Profesiones
        public IQueryable<Profesion> GetProfesions()
        {
            return db.Profesiones;
        }

        // GET: api/Profesiones/5
        [ResponseType(typeof(Profesion))]
        public IHttpActionResult GetProfesion(int id)
        {
            Profesion profesion = db.Profesiones.Find(id);
            if (profesion == null)
            {
                return NotFound();
            }

            return Ok(profesion);
        }

        // PUT: api/Profesiones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProfesion(int id, Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != profesion.Id)
            {
                return BadRequest();
            }

            db.Entry(profesion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfesionExists(id))
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

        // POST: api/Profesiones
        [ResponseType(typeof(Profesion))]
        public IHttpActionResult PostProfesion(Profesion profesion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Profesiones.Add(profesion);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = profesion.Id }, profesion);
        }

        // DELETE: api/Profesiones/5
        [ResponseType(typeof(Profesion))]
        public IHttpActionResult DeleteProfesion(int id)
        {
            Profesion profesion = db.Profesiones.Find(id);
            if (profesion == null)
            {
                return NotFound();
            }

            db.Profesiones.Remove(profesion);
            db.SaveChanges();

            return Ok(profesion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProfesionExists(int id)
        {
            return db.Profesiones.Count(e => e.Id == id) > 0;
        }
    }
}