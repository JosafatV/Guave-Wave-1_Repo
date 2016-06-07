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
    public class VentaPorCajaController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/VentaPorCaja
        public IQueryable<VENTA_POR_CAJA> GetVENTA_POR_CAJA()
        {
            return db.VENTA_POR_CAJA;
        }

        // GET: api/VentaPorCaja/5
        [ResponseType(typeof(VENTA_POR_CAJA))]
        public IHttpActionResult GetVENTA_POR_CAJA(int id)
        {
            VENTA_POR_CAJA vENTA_POR_CAJA = db.VENTA_POR_CAJA.Find(id);
            if (vENTA_POR_CAJA == null)
            {
                return NotFound();
            }

            return Ok(vENTA_POR_CAJA);
        }

        // PUT: api/VentaPorCaja/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTA_POR_CAJA(int id, VENTA_POR_CAJA vENTA_POR_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTA_POR_CAJA.IdVenta)
            {
                return BadRequest();
            }

            db.Entry(vENTA_POR_CAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTA_POR_CAJAExists(id))
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

        // POST: api/VentaPorCaja
        [ResponseType(typeof(VENTA_POR_CAJA))]
        public IHttpActionResult PostVENTA_POR_CAJA(VENTA_POR_CAJA vENTA_POR_CAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VENTA_POR_CAJA.Add(vENTA_POR_CAJA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VENTA_POR_CAJAExists(vENTA_POR_CAJA.IdVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vENTA_POR_CAJA.IdVenta }, vENTA_POR_CAJA);
        }

        // DELETE: api/VentaPorCaja/5
        [ResponseType(typeof(VENTA_POR_CAJA))]
        public IHttpActionResult DeleteVENTA_POR_CAJA(int id)
        {
            VENTA_POR_CAJA vENTA_POR_CAJA = db.VENTA_POR_CAJA.Find(id);
            if (vENTA_POR_CAJA == null)
            {
                return NotFound();
            }

            db.VENTA_POR_CAJA.Remove(vENTA_POR_CAJA);
            db.SaveChanges();

            return Ok(vENTA_POR_CAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTA_POR_CAJAExists(int id)
        {
            return db.VENTA_POR_CAJA.Count(e => e.IdVenta == id) > 0;
        }
    }
}