﻿using System;
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
    public class IdiomasController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Idiomas
        public IQueryable<Idioma> GetIdiomas()
        {
            return db.Idiomas;
        }

        // GET: api/Idiomas/5
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult GetIdioma(int id)
        {
            Idioma idioma = db.Idiomas.Find(id);
            if (idioma == null)
            {
                return NotFound();
            }

            return Ok(idioma);
        }

        // PUT: api/Idiomas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIdioma(int id, Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != idioma.Id)
            {
                return BadRequest();
            }

            db.Entry(idioma).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdiomaExists(id))
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

        // POST: api/Idiomas
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult PostIdioma(Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Idiomas.Add(idioma);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = idioma.Id }, idioma);
        }

        // DELETE: api/Idiomas/5
        [ResponseType(typeof(Idioma))]
        public IHttpActionResult DeleteIdioma(int id)
        {
            Idioma idioma = db.Idiomas.Find(id);
            if (idioma == null)
            {
                return NotFound();
            }

            db.Idiomas.Remove(idioma);
            db.SaveChanges();

            return Ok(idioma);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool IdiomaExists(int id)
        {
            return db.Idiomas.Count(e => e.Id == id) > 0;
        }
    }
}