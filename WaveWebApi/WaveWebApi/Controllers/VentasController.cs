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
    public class VentasController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/Ventas
        public IQueryable<VENTA> GetVENTA()
        {
            return db.VENTA;
        }

        // GET: api/Ventas/5
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult GetVENTA(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return NotFound();
            }

            return Ok(vENTA);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTA(int id, VENTA vENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTA.IdVenta)
            {
                return BadRequest();
            }

            db.Entry(vENTA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTAExists(id))
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

        // POST: api/Ventas
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult PostVENTA(VENTA vENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VENTA.Add(vENTA);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vENTA.IdVenta }, vENTA);
        }

        // DELETE: api/Ventas/5
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult DeleteVENTA(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return NotFound();
            }

            db.VENTA.Remove(vENTA);
            db.SaveChanges();

            return Ok(vENTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTAExists(int id)
        {
            return db.VENTA.Count(e => e.IdVenta == id) > 0;
        }
    }
}