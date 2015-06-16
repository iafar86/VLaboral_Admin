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
    public class RequisitosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Requisitos
        public IQueryable<Requisito> GetRequisitoes()
        {
            return db.Requisitos;
        }

        // GET: api/Requisitos/5
        [ResponseType(typeof(Requisito))]
        public IHttpActionResult GetRequisito(int id)
        {
            Requisito requisito = db.Requisitos.Find(id);
            if (requisito == null)
            {
                return NotFound();
            }

            return Ok(requisito);
        }

        // PUT: api/Requisitos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRequisito(int id, Requisito requisito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != requisito.Id)
            {
                return BadRequest();
            }

            db.Entry(requisito).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequisitoExists(id))
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

        // POST: api/Requisitos
        [ResponseType(typeof(Requisito))]
        public IHttpActionResult PostRequisito(Requisito requisito)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Requisitos.Add(requisito);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RequisitoExists(requisito.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = requisito.Id }, requisito);
        }

        // DELETE: api/Requisitos/5
        [ResponseType(typeof(Requisito))]
        public IHttpActionResult DeleteRequisito(int id)
        {
            Requisito requisito = db.Requisitos.Find(id);
            if (requisito == null)
            {
                return NotFound();
            }

            db.Requisitos.Remove(requisito);
            db.SaveChanges();

            return Ok(requisito);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RequisitoExists(int id)
        {
            return db.Requisitos.Count(e => e.Id == id) > 0;
        }
    }
}