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

        [HttpGet]
        [Route("api/ProductoPorSucursal")]

        public IQueryable<View_ProductoPorSucursal> GetPRODUCTO_POR_SUCURSAL()
        {
            return db.View_ProductoPorSucursal;
        }

        [HttpGet]
        [Route("api/ProductoPorSucursal/Sucursal/{idSucursal}/Producto/{idProducto}")]
        [ResponseType(typeof(View_ProductoPorSucursal))]
        public IHttpActionResult GetPRODUCTO_POR_SUCURSAL(int idSucursal, int idProducto)
        {
            View_ProductoPorSucursal pRODUCTO_POR_SUCURSAL = db.View_ProductoPorSucursal.Find(idSucursal,idProducto);
            if (pRODUCTO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_SUCURSAL);
        }

        // PUT: api/ProductoPorSucursal/5
      /*  [ResponseType(typeof(void))]
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
        }*/

        [HttpPost]
        [Route("api/ProductoPorSucursal")]
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
                if (PRODUCTO_POR_SUCURSALExists(pRODUCTO_POR_SUCURSAL.IdSucursal, pRODUCTO_POR_SUCURSAL.IdProducto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pRODUCTO_POR_SUCURSAL);
        }

        [HttpDelete]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idProducto}")]
        [ResponseType(typeof(PRODUCTO_POR_SUCURSAL))]
        public IHttpActionResult DeletePRODUCTO_POR_SUCURSAL(int idSucursal, int idProducto)
        {
            PRODUCTO_POR_SUCURSAL pRODUCTO_POR_SUCURSAL = db.PRODUCTO_POR_SUCURSAL.Find(idSucursal,idProducto);
            if (pRODUCTO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            pRODUCTO_POR_SUCURSAL.Estado = "I";
            db.Entry(pRODUCTO_POR_SUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_SUCURSALExists(idSucursal, idProducto))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool PRODUCTO_POR_SUCURSALExists(int idSucursal, int idProducto)
        {
            return db.PRODUCTO_POR_SUCURSAL.Find(idSucursal, idProducto) != null;
        }

        [HttpOptions]
        [Route("api/ProductoPorSucursal")]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idProducto}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}