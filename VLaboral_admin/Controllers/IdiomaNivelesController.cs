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
    public class IdiomaNivelesController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/IdiomaNiveles
        public IQueryable<IdiomaNivel> GetIdiomaNivels()
        {
            return db.IdiomaNiveles;
        }

        // GET: api/IdiomaNiveles/5
        [ResponseType(typeof(IdiomaNivel))]
        public IHttpActionResult GetIdiomaNivel(int id)
        {
            IdiomaNivel idiomaNivel = db.IdiomaNiveles.Find(id);
            if (idiomaNivel == null)
            {
                return NotFound();
            }

            return Ok(idiomaNivel);
        }

        // PUT: api/IdiomaNiveles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdiomaNivel(int id, IdiomaNivel idiomaNivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idiomaNivel.Id)
            {
                return BadRequest();
            }

            db.Entry(idiomaNivel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaNivelExists(id))
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

        // POST: api/IdiomaNiveles
        [ResponseType(typeof(IdiomaNivel))]
        public IHttpActionResult PostIdiomaNivel(IdiomaNivel idiomaNivel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.IdiomaNiveles.Add(idiomaNivel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = idiomaNivel.Id }, idiomaNivel);
        }

        // DELETE: api/IdiomaNiveles/5
        [ResponseType(typeof(IdiomaNivel))]
        public IHttpActionResult DeleteIdiomaNivel(int id)
        {
            IdiomaNivel idiomaNivel = db.IdiomaNiveles.Find(id);
            if (idiomaNivel == null)
            {
                return NotFound();
            }

            db.IdiomaNiveles.Remove(idiomaNivel);
            db.SaveChanges();

            return Ok(idiomaNivel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdiomaNivelExists(int id)
        {
            return db.IdiomaNiveles.Count(e => e.Id == id) > 0;
        }
    }
}