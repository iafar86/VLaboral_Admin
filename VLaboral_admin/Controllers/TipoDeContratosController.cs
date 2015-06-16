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
    public class TipoDeContratosController : ApiController
    {
        private VLaboral_Context db = new VLaboral_Context();

        // GET: api/TipoDeContratos
        public IQueryable<TipoDeContrato> GetTipoDeContratoes()
        {
            return db.TipoDeContratos;
        }

        // GET: api/TipoDeContratos/5
        [ResponseType(typeof(TipoDeContrato))]
        public IHttpActionResult GetTipoDeContrato(int id)
        {
            TipoDeContrato tipoDeContrato = db.TipoDeContratos.Find(id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            return Ok(tipoDeContrato);
        }

        // PUT: api/TipoDeContratos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTipoDeContrato(int id, TipoDeContrato tipoDeContrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoDeContrato.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoDeContrato).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoDeContratoExists(id))
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

        // POST: api/TipoDeContratos
        [ResponseType(typeof(TipoDeContrato))]
        public IHttpActionResult PostTipoDeContrato(TipoDeContrato tipoDeContrato)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TipoDeContratos.Add(tipoDeContrato);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tipoDeContrato.Id }, tipoDeContrato);
        }

        // DELETE: api/TipoDeContratos/5
        [ResponseType(typeof(TipoDeContrato))]
        public IHttpActionResult DeleteTipoDeContrato(int id)
        {
            TipoDeContrato tipoDeContrato = db.TipoDeContratos.Find(id);
            if (tipoDeContrato == null)
            {
                return NotFound();
            }

            db.TipoDeContratos.Remove(tipoDeContrato);
            db.SaveChanges();

            return Ok(tipoDeContrato);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoDeContratoExists(int id)
        {
            return db.TipoDeContratos.Count(e => e.Id == id) > 0;
        }
    }
}