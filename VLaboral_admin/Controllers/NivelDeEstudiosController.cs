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
    public class NivelDeEstudiosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/NivelDeEstudios
        public IQueryable<NivelDeEstudio> GetNivelDeEstudios()
        {
            return db.NivelDeEstudios;
        }

        // GET: api/NivelDeEstudios/5
        [ResponseType(typeof(NivelDeEstudio))]
        public IHttpActionResult GetNivelDeEstudio(int id)
        {
            NivelDeEstudio nivelDeEstudio = db.NivelDeEstudios.Find(id);
            if (nivelDeEstudio == null)
            {
                return NotFound();
            }

            return Ok(nivelDeEstudio);
        }

        // PUT: api/NivelDeEstudios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNivelDeEstudio(int id, NivelDeEstudio nivelDeEstudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nivelDeEstudio.Id)
            {
                return BadRequest();
            }

            db.Entry(nivelDeEstudio).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NivelDeEstudioExists(id))
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

        // POST: api/NivelDeEstudios
        [ResponseType(typeof(NivelDeEstudio))]
        public IHttpActionResult PostNivelDeEstudio(NivelDeEstudio nivelDeEstudio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NivelDeEstudios.Add(nivelDeEstudio);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nivelDeEstudio.Id }, nivelDeEstudio);
        }

        // DELETE: api/NivelDeEstudios/5
        [ResponseType(typeof(NivelDeEstudio))]
        public IHttpActionResult DeleteNivelDeEstudio(int id)
        {
            NivelDeEstudio nivelDeEstudio = db.NivelDeEstudios.Find(id);
            if (nivelDeEstudio == null)
            {
                return NotFound();
            }

            db.NivelDeEstudios.Remove(nivelDeEstudio);
            db.SaveChanges();

            return Ok(nivelDeEstudio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NivelDeEstudioExists(int id)
        {
            return db.NivelDeEstudios.Count(e => e.Id == id) > 0;
        }
    }
}