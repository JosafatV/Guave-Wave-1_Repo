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
    public class ProductoPorVentaController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/ProductoPorVenta
        public IQueryable<PRODUCTO_POR_VENTA> GetPRODUCTO_POR_VENTA()
        {
            return db.PRODUCTO_POR_VENTA;
        }

        // GET: api/ProductoPorVenta/5
        [ResponseType(typeof(PRODUCTO_POR_VENTA))]
        public IHttpActionResult GetPRODUCTO_POR_VENTA(int id)
        {
            PRODUCTO_POR_VENTA pRODUCTO_POR_VENTA = db.PRODUCTO_POR_VENTA.Find(id);
            if (pRODUCTO_POR_VENTA == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_VENTA);
        }

        // PUT: api/ProductoPorVenta/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO_POR_VENTA(int id, PRODUCTO_POR_VENTA pRODUCTO_POR_VENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO_POR_VENTA.IdProducto)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO_POR_VENTA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_VENTAExists(id))
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

        // POST: api/ProductoPorVenta
        [ResponseType(typeof(PRODUCTO_POR_VENTA))]
        public IHttpActionResult PostPRODUCTO_POR_VENTA(PRODUCTO_POR_VENTA pRODUCTO_POR_VENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTO_POR_VENTA.Add(pRODUCTO_POR_VENTA);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTO_POR_VENTAExists(pRODUCTO_POR_VENTA.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO_POR_VENTA.IdProducto }, pRODUCTO_POR_VENTA);
        }

        // DELETE: api/ProductoPorVenta/5
        [ResponseType(typeof(PRODUCTO_POR_VENTA))]
        public IHttpActionResult DeletePRODUCTO_POR_VENTA(int id)
        {
            PRODUCTO_POR_VENTA pRODUCTO_POR_VENTA = db.PRODUCTO_POR_VENTA.Find(id);
            if (pRODUCTO_POR_VENTA == null)
            {
                return NotFound();
            }

            db.PRODUCTO_POR_VENTA.Remove(pRODUCTO_POR_VENTA);
            db.SaveChanges();

            return Ok(pRODUCTO_POR_VENTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTO_POR_VENTAExists(int id)
        {
            return db.PRODUCTO_POR_VENTA.Count(e => e.IdProducto == id) > 0;
        }
    }
}