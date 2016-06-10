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


        [HttpGet]
        public IQueryable<View_EmpleadoPorSucursal> GetEMPLEADO_POR_SUCURSAL()
        {
            return db.View_EmpleadoPorSucursal;
        }

     
        [HttpGet]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idEmpleado}")]
        [ResponseType(typeof(View_EmpleadoPorSucursal))]
        public IHttpActionResult GetEMPLEADO_POR_SUCURSAL(int idSucursal, int idEmpleado)
        {
            View_EmpleadoPorSucursal eMPLEADO_POR_SUCURSAL = db.View_EmpleadoPorSucursal.Find(idSucursal,idEmpleado);
            if (eMPLEADO_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO_POR_SUCURSAL);
        }

        // POST: api/EmpleadoPorSucursal
        [HttpPost]
        [Route("api/EmpleadoPorSucursal")]
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
                if (EMPLEADO_POR_SUCURSALExists(eMPLEADO_POR_SUCURSAL.IdSucursal,eMPLEADO_POR_SUCURSAL.IdEmpleado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(eMPLEADO_POR_SUCURSAL);
        }

        // DELETE: api/EmpleadoPorSucursal/5
        [HttpDelete]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idEmpleado}")]
        [ResponseType(typeof(EMPLEADO_POR_SUCURSAL))]
        public IHttpActionResult DeleteEMPLEADO_POR_SUCURSAL(int idSucursal, int idEmpleado)
        {
            EMPLEADO_POR_SUCURSAL eMPLEADO_POR_SUCURSAL = db.EMPLEADO_POR_SUCURSAL.Find(idSucursal, idEmpleado);
            if (eMPLEADO_POR_SUCURSAL == null)
            {
                return NotFound();
            }
            eMPLEADO_POR_SUCURSAL.Estado = "I";
            db.Entry(eMPLEADO_POR_SUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADO_POR_SUCURSALExists(idSucursal, idEmpleado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

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

        private bool EMPLEADO_POR_SUCURSALExists(int idSucursal, int idEmpleado)
        {
            return db.EMPLEADO_POR_SUCURSAL.Find(idSucursal,idEmpleado) !=null;
        }


        [HttpOptions]
        [Route("api/EmpleadoPorSucursal")]
        [Route("api/ProductoPorSucursal/{idSucursal}/{idEmpleado}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}