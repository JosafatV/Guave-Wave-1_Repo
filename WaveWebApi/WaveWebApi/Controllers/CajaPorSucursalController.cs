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
    public class CajaPorSucursalController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/CajaPorSucursal
        public IQueryable<CAJA_POR_SUCURSAL> GetCAJA_POR_SUCURSAL()
        {
            return db.CAJA_POR_SUCURSAL;
        }

        // GET: api/CajaPorSucursal/5
        [ResponseType(typeof(CAJA_POR_SUCURSAL))]
        public IHttpActionResult GetCAJA_POR_SUCURSAL(int id)
        {
            CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL = db.CAJA_POR_SUCURSAL.Find(id);
            if (cAJA_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(cAJA_POR_SUCURSAL);
        }

        // PUT: api/CajaPorSucursal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCAJA_POR_SUCURSAL(int id, CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAJA_POR_SUCURSAL.IdCaja)
            {
                return BadRequest();
            }

            db.Entry(cAJA_POR_SUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJA_POR_SUCURSALExists(id))
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

        // POST: api/CajaPorSucursal
        [ResponseType(typeof(CAJA_POR_SUCURSAL))]
        public IHttpActionResult PostCAJA_POR_SUCURSAL(CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAJA_POR_SUCURSAL.Add(cAJA_POR_SUCURSAL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CAJA_POR_SUCURSALExists(cAJA_POR_SUCURSAL.IdCaja))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cAJA_POR_SUCURSAL.IdCaja }, cAJA_POR_SUCURSAL);
        }

        // DELETE: api/CajaPorSucursal/5
        [ResponseType(typeof(CAJA_POR_SUCURSAL))]
        public IHttpActionResult DeleteCAJA_POR_SUCURSAL(int id)
        {
            CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL = db.CAJA_POR_SUCURSAL.Find(id);
            if (cAJA_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            db.CAJA_POR_SUCURSAL.Remove(cAJA_POR_SUCURSAL);
            db.SaveChanges();

            return Ok(cAJA_POR_SUCURSAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAJA_POR_SUCURSALExists(int id)
        {
            return db.CAJA_POR_SUCURSAL.Count(e => e.IdCaja == id) > 0;
        }
    }
}