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
    public class ProveedoresController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();


        [HttpGet]
        [Route("api/Proveedores")]
        public IQueryable<PROVEEDOR> GetPROVEEDOR()
        {
            return db.PROVEEDOR;
        }

    
        [HttpGet]
        [Route("api/Proveedores/{id}")]
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult GetPROVEEDOR(int id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return NotFound();
            }

            return Ok(pROVEEDOR);
        }

       
        [HttpPut]
        [Route("api/Proveedores/{id}")]
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult PutPROVEEDOR(int id, PROVEEDOR pROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pROVEEDOR.IdProveedor)
            {
                return BadRequest();
            }

            db.Entry(pROVEEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROVEEDORExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pROVEEDOR);
        }

        [HttpPost]
        [Route("api/Proveedores")]
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult PostPROVEEDOR(PROVEEDOR pROVEEDOR)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PROVEEDOR.Add(pROVEEDOR);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pROVEEDOR.IdProveedor }, pROVEEDOR);
        }

        [HttpDelete]
        [Route("api/Proveedores/{id}")]
        [ResponseType(typeof(PROVEEDOR))]
        public IHttpActionResult DeletePROVEEDOR(int id)
        {
            PROVEEDOR pROVEEDOR = db.PROVEEDOR.Find(id);
            if (pROVEEDOR == null)
            {
                return NotFound();
            }

            pROVEEDOR.Estado = "I";
            db.Entry(pROVEEDOR).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PROVEEDORExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pROVEEDOR);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PROVEEDORExists(int id)
        {
            return db.PROVEEDOR.Count(e => e.IdProveedor == id) > 0;
        }

        [HttpOptions]
        [Route("api/Proveedores")]
        [Route("api/Proveedores/{id}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}