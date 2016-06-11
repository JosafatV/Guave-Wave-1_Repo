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
            View_ProductoPorSucursal pRODUCTO_POR_SUCURSAL = db.View_ProductoPorSucursal.Find(idProducto, idSucursal);
            if (pRODUCTO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(pRODUCTO_POR_SUCURSAL);
        }

        // PUT: api/ProductoPorSucursal/5
        [HttpPut]
        [Route("api/ProductoPorSucursal/{idProducto}/{idSucursal}/{cantidadDeMas}")]
        [ResponseType(typeof(PRODUCTO_POR_SUCURSAL))]
        public IHttpActionResult PutPRODUCTO_POR_SUCURSAL(int idProducto , int idSucursal ,short cantidadDeMas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            
            db.sp_reStock(idProducto, cantidadDeMas, idSucursal);
            db.SaveChanges();
            PRODUCTO_POR_SUCURSAL prod_x_sucursal = db.PRODUCTO_POR_SUCURSAL.Find(idProducto, idSucursal);

            return Ok(prod_x_sucursal);
        }

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
                if (PRODUCTO_POR_SUCURSALExists(pRODUCTO_POR_SUCURSAL.IdProducto ,pRODUCTO_POR_SUCURSAL.IdSucursal ))
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
                if (!PRODUCTO_POR_SUCURSALExists(idProducto ,idSucursal))
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

        private bool PRODUCTO_POR_SUCURSALExists(int idProducto ,int  idSucursal )
        {
            return db.PRODUCTO_POR_SUCURSAL.Find(idProducto , idSucursal) != null;
        }

        [HttpOptions]
        [Route("api/ProductoPorSucursal")]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idProducto}")]
        [Route("api/ProductoPorSucursal/{idProducto}/{idSucursal}/{cantidadDeMas}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}