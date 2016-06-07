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
    public class ProductoPorPreveedorController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/ProductoPorPreveedor
        public IQueryable<PRODUCTO_POR_PROVEEDOR> GetPRODUCTO_POR_PROVEEDOR()
        {
            return db.PRODUCTO_POR_PROVEEDOR;
        }

        // GET: api/ProductoPorPreveedor/5
        [ResponseType(typeof(PRODUCTO_POR_PROVEEDOR))]
        public IHttpActionResult GetPRODUCTO_POR_PROVEEDOR(int id)
        {
            PRODUCTO_POR_PROVEEDOR pRODUCTO_POR_PROVEEDOR = db.PRODUCTO_POR_PROVEEDOR.Find(id);
            if (pRODUCTO_POR_PROVEEDOR == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_PROVEEDOR);
        }

        // PUT: api/ProductoPorPreveedor/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO_POR_PROVEEDOR(int id, PRODUCTO_POR_PROVEEDOR pRODUCTO_POR_PROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO_POR_PROVEEDOR.IdProducto)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO_POR_PROVEEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_PROVEEDORExists(id))
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

        // POST: api/ProductoPorPreveedor
        [ResponseType(typeof(PRODUCTO_POR_PROVEEDOR))]
        public IHttpActionResult PostPRODUCTO_POR_PROVEEDOR(PRODUCTO_POR_PROVEEDOR pRODUCTO_POR_PROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTO_POR_PROVEEDOR.Add(pRODUCTO_POR_PROVEEDOR);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTO_POR_PROVEEDORExists(pRODUCTO_POR_PROVEEDOR.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO_POR_PROVEEDOR.IdProducto }, pRODUCTO_POR_PROVEEDOR);
        }

        // DELETE: api/ProductoPorPreveedor/5
        [ResponseType(typeof(PRODUCTO_POR_PROVEEDOR))]
        public IHttpActionResult DeletePRODUCTO_POR_PROVEEDOR(int id)
        {
            PRODUCTO_POR_PROVEEDOR pRODUCTO_POR_PROVEEDOR = db.PRODUCTO_POR_PROVEEDOR.Find(id);
            if (pRODUCTO_POR_PROVEEDOR == null)
            {
                return NotFound();
            }

            db.PRODUCTO_POR_PROVEEDOR.Remove(pRODUCTO_POR_PROVEEDOR);
            db.SaveChanges();

            return Ok(pRODUCTO_POR_PROVEEDOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTO_POR_PROVEEDORExists(int id)
        {
            return db.PRODUCTO_POR_PROVEEDOR.Count(e => e.IdProducto == id) > 0;
        }
    }
}