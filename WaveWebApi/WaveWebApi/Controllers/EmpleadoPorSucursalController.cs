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
    public class EmpleadoPorSucursalController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/EmpleadoPorSucursal
        public IQueryable<EMPLEADO_POR_SUCURSAL> GetEMPLEADO_POR_SUCURSAL()
        {
            return db.EMPLEADO_POR_SUCURSAL;
        }

        // GET: api/EmpleadoPorSucursal/5
        [ResponseType(typeof(EMPLEADO_POR_SUCURSAL))]
        public IHttpActionResult GetEMPLEADO_POR_SUCURSAL(int id)
        {
            EMPLEADO_POR_SUCURSAL eMPLEADO_POR_SUCURSAL = db.EMPLEADO_POR_SUCURSAL.Find(id);
            if (eMPLEADO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO_POR_SUCURSAL);
        }

        // PUT: api/EmpleadoPorSucursal/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLEADO_POR_SUCURSAL(int id, EMPLEADO_POR_SUCURSAL eMPLEADO_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADO_POR_SUCURSAL.IdSucursal)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADO_POR_SUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADO_POR_SUCURSALExists(id))
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

        // POST: api/EmpleadoPorSucursal
        [ResponseType(typeof(EMPLEADO_POR_SUCURSAL))]
        public IHttpActionResult PostEMPLEADO_POR_SUCURSAL(EMPLEADO_POR_SUCURSAL eMPLEADO_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLEADO_POR_SUCURSAL.Add(eMPLEADO_POR_SUCURSAL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPLEADO_POR_SUCURSALExists(eMPLEADO_POR_SUCURSAL.IdSucursal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPLEADO_POR_SUCURSAL.IdSucursal }, eMPLEADO_POR_SUCURSAL);
        }

        // DELETE: api/EmpleadoPorSucursal/5
        [ResponseType(typeof(EMPLEADO_POR_SUCURSAL))]
        public IHttpActionResult DeleteEMPLEADO_POR_SUCURSAL(int id)
        {
            EMPLEADO_POR_SUCURSAL eMPLEADO_POR_SUCURSAL = db.EMPLEADO_POR_SUCURSAL.Find(id);
            if (eMPLEADO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            db.EMPLEADO_POR_SUCURSAL.Remove(eMPLEADO_POR_SUCURSAL);
            db.SaveChanges();

            return Ok(eMPLEADO_POR_SUCURSAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADO_POR_SUCURSALExists(int id)
        {
            return db.EMPLEADO_POR_SUCURSAL.Count(e => e.IdSucursal == id) > 0;
        }
    }
}