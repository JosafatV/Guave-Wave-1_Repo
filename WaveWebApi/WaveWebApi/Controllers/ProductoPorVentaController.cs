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
        public IQueryable<View_ProductoPorVenta> GetPRODUCTO_POR_VENTA()
        {
            return db.View_ProductoPorVenta;
        }

        // GET: api/ProductoPorVenta/5
        [HttpGet]
        [Route("api/ProductoPorVenta/{idProducto}/{idVenta}")]
        [ResponseType(typeof(View_ProductoPorVenta))]
        public IHttpActionResult GetPRODUCTO_POR_VENTA(int idProducto, int idVenta)
        {
            View_ProductoPorVenta pRODUCTO_POR_VENTA = db.View_ProductoPorVenta.Find(idProducto, idVenta);
            if (pRODUCTO_POR_VENTA == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_VENTA);
        }

     /*   // PUT: api/ProductoPorVenta/5
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
*/
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
                if (PRODUCTO_POR_VENTAExists(pRODUCTO_POR_VENTA.IdProducto, pRODUCTO_POR_VENTA.IdVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pRODUCTO_POR_VENTA);
        }

        // DELETE: api/ProductoPorVenta/5
        [HttpDelete]
        [Route("api/ProductoPorVenta/{idProducto}/{idVenta}")]
        [ResponseType(typeof(PRODUCTO_POR_VENTA))]
        public IHttpActionResult DeletePRODUCTO_POR_VENTA(int idProducto, int idVenta)
        {
            PRODUCTO_POR_VENTA pRODUCTO_POR_VENTA = db.PRODUCTO_POR_VENTA.Find(idProducto, idVenta);
            if (pRODUCTO_POR_VENTA == null)
            {
                return NotFound();
            }

            pRODUCTO_POR_VENTA.Estado = "I";
            db.Entry(pRODUCTO_POR_VENTA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_VENTAExists(idProducto, idVenta))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool PRODUCTO_POR_VENTAExists(int idProducto, int idVenta)
        {
            return db.PRODUCTO_POR_VENTA.Find(idProducto, idVenta) != null;
        }
    }
}