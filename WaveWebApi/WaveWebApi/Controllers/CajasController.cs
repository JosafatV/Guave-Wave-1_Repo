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
using WaveWebApi.Models;

namespace WaveWebApi.Controllers
{
    public class CajasController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/Cajas
        public IQueryable<CAJA> GetCAJA()
        {
            return db.CAJA;
        }

        // GET: api/Cajas/5
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult GetCAJA(int id)
        {
            CAJA cAJA = db.CAJA.Find(id);
            if (cAJA == null)
            {
                return NotFound();
            }

            return Ok(cAJA);
        }

        // PUT: api/Cajas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAJA(int id, CAJA cAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAJA.IdCaja)
            {
                return BadRequest();
            }

            db.Entry(cAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJAExists(id))
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

        // POST: api/Cajas
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult PostCAJA(CAJA cAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAJA.Add(cAJA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cAJA.IdCaja }, cAJA);
        }

        // DELETE: api/Cajas/5
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult DeleteCAJA(int id)
        {
            CAJA cAJA = db.CAJA.Find(id);
            if (cAJA == null)
            {
                return NotFound();
            }

            db.CAJA.Remove(cAJA);
            db.SaveChanges();

            return Ok(cAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAJAExists(int id)
        {
            return db.CAJA.Count(e => e.IdCaja == id) > 0;
        }
    }
}