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
    public class ProductoPorSucursalController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/ProductoPorSucursal
        public IQueryable<PRODUCTO_POR_SUCURSAL> GetPRODUCTO_POR_SUCURSAL()
        {
            return db.PRODUCTO_POR_SUCURSAL;
        }

        // GET: api/ProductoPorSucursal/5
        [ResponseType(typeof(PRODUCTO_POR_SUCURSAL))]
        public IHttpActionResult GetPRODUCTO_POR_SUCURSAL(int id)
        {
            PRODUCTO_POR_SUCURSAL pRODUCTO_POR_SUCURSAL = db.PRODUCTO_POR_SUCURSAL.Find(id);
            if (pRODUCTO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_SUCURSAL);
        }

        // PUT: api/ProductoPorSucursal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPRODUCTO_POR_SUCURSAL(int id, PRODUCTO_POR_SUCURSAL pRODUCTO_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO_POR_SUCURSAL.IdSucursal)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO_POR_SUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_SUCURSALExists(id))
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

        // POST: api/ProductoPorSucursal
        [ResponseType(typeof(PRODUCTO_POR_SUCURSAL))]
        public IHttpActionResult PostPRODUCTO_POR_SUCURSAL(PRODUCTO_POR_SUCURSAL pRODUCTO_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTO_POR_SUCURSAL.Add(pRODUCTO_POR_SUCURSAL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PRODUCTO_POR_SUCURSALExists(pRODUCTO_POR_SUCURSAL.IdSucursal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = pRODUCTO_POR_SUCURSAL.IdSucursal }, pRODUCTO_POR_SUCURSAL);
        }

        // DELETE: api/ProductoPorSucursal/5
        [ResponseType(typeof(PRODUCTO_POR_SUCURSAL))]
        public IHttpActionResult DeletePRODUCTO_POR_SUCURSAL(int id)
        {
            PRODUCTO_POR_SUCURSAL pRODUCTO_POR_SUCURSAL = db.PRODUCTO_POR_SUCURSAL.Find(id);
            if (pRODUCTO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            db.PRODUCTO_POR_SUCURSAL.Remove(pRODUCTO_POR_SUCURSAL);
            db.SaveChanges();

            return Ok(pRODUCTO_POR_SUCURSAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTO_POR_SUCURSALExists(int id)
        {
            return db.PRODUCTO_POR_SUCURSAL.Count(e => e.IdSucursal == id) > 0;
        }
    }
}