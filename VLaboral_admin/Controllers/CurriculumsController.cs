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
    public class CurriculumsController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/Curriculums
        public IQueryable<Curriculum> GetCurriculums()
        {
            return db.Curriculums;
        }

        // GET: api/Curriculums/5
        [ResponseType(typeof(Curriculum))]
        public IHttpActionResult GetCurriculum(int id)
        {
            Curriculum curriculum = db.Curriculums.Find(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            return Ok(curriculum);
        }

        // PUT: api/Curriculums/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCurriculum(int id, Curriculum curriculum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != curriculum.Id)
            {
                return BadRequest();
            }

            db.Entry(curriculum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurriculumExists(id))
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

        // POST: api/Curriculums
        [ResponseType(typeof(Curriculum))]
        public IHttpActionResult PostCurriculum(Curriculum curriculum)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Curriculums.Add(curriculum);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = curriculum.Id }, curriculum);
        }

        // DELETE: api/Curriculums/5
        [ResponseType(typeof(Curriculum))]
        public IHttpActionResult DeleteCurriculum(int id)
        {
            Curriculum curriculum = db.Curriculums.Find(id);
            if (curriculum == null)
            {
                return NotFound();
            }

            db.Curriculums.Remove(curriculum);
            db.SaveChanges();

            return Ok(curriculum);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurriculumExists(int id)
        {
            return db.Curriculums.Count(e => e.Id == id) > 0;
        }
    }
}