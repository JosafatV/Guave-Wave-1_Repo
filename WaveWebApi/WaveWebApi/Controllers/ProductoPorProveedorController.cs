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
    public class ProductoPorProveedorController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/ProductoPorPreveedor
        [HttpGet]
        public IQueryable<View_ProductoPorProveedor> GetPRODUCTO_POR_PROVEEDOR()
        {
            return db.View_ProductoPorProveedor;
        }

        // GET: api/ProductoPorPreveedor/5
        [HttpGet]
        [Route("api/ProductoPorProveedor/{idProducto}/{idProveedor}")]
        [ResponseType(typeof(View_ProductoPorProveedor))]
        public IHttpActionResult GetPRODUCTO_POR_PROVEEDOR(int idProducto, int idProveedor)
        {
            View_ProductoPorProveedor pRODUCTO_POR_PROVEEDOR = db.View_ProductoPorProveedor.Find(idProducto,idProveedor);
            if (pRODUCTO_POR_PROVEEDOR == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_PROVEEDOR);
        }
     

       
        [HttpPost]
        [Route("api/ProductoPorPreveedor")]
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
                if (PRODUCTO_POR_PROVEEDORExists(pRODUCTO_POR_PROVEEDOR.IdProducto, pRODUCTO_POR_PROVEEDOR.IdProveedor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pRODUCTO_POR_PROVEEDOR);
        }


        [HttpDelete]
        [Route("api/ProductoPorProveedor/{idProducto}/{idProveedor}")]
        [ResponseType(typeof(PRODUCTO_POR_PROVEEDOR))]
        public IHttpActionResult DeletePRODUCTO_POR_PROVEEDOR(int idProducto, int idProveedor)
        {
            PRODUCTO_POR_PROVEEDOR pRODUCTO_POR_PROVEEDOR = db.PRODUCTO_POR_PROVEEDOR.Find(idProducto, idProveedor);
            if (pRODUCTO_POR_PROVEEDOR == null)
            {
                return NotFound();
            }

            pRODUCTO_POR_PROVEEDOR.Estado = "I"; //Deletion
            db.Entry(pRODUCTO_POR_PROVEEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTO_POR_PROVEEDORExists(idProducto, idProveedor))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool PRODUCTO_POR_PROVEEDORExists(int idProducto, int idProveedor)
        {
            return db.PRODUCTO_POR_PROVEEDOR.Find(idProducto, idProveedor) != null;
        }

        [HttpOptions]
        [Route("api/ProductoPorPreveedor")]
        [Route("api/ProductoPorProveedor/{idProducto}/{idProveedor}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}