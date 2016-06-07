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
    public class EmpleadoPorRolController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/EmpleadoPorRol
        [HttpGet]
        public IQueryable<View_EmpleadoPorRol> GetEMPLEADO_POR_ROL()
        {
            return db.View_EmpleadoPorRol;
        }

        // GET: api/EmpleadoPorRol/5
        [HttpGet]
        [Route("api/EmpleadoPorRol/{idRol}/{idEmpleado}")]
        [ResponseType(typeof(View_EmpleadoPorRol))]
        public IHttpActionResult GetEMPLEADO_POR_ROL(byte idRol , int idEmpleado)
        {
            View_EmpleadoPorRol eMPLEADO_POR_ROL = db.View_EmpleadoPorRol.Find(idRol,idEmpleado);
            if (eMPLEADO_POR_ROL == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO_POR_ROL);
        }

        // POST: api/EmpleadoPorRol
        [ResponseType(typeof(EMPLEADO_POR_ROL))]
        public IHttpActionResult PostEMPLEADO_POR_ROL(EMPLEADO_POR_ROL eMPLEADO_POR_ROL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLEADO_POR_ROL.Add(eMPLEADO_POR_ROL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EMPLEADO_POR_ROLExists(eMPLEADO_POR_ROL.IdRol,eMPLEADO_POR_ROL.IdEmpleado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(eMPLEADO_POR_ROL);
        }

        // DELETE: api/EmpleadoPorRol/5
        [HttpDelete]
        [Route("api/EmpleadoPorRol/{idRol}/{idEmpleado}")]
        [ResponseType(typeof(EMPLEADO_POR_ROL))]
        public IHttpActionResult DeleteEMPLEADO_POR_ROL(byte idRol, int idEmpleado)
        {
            EMPLEADO_POR_ROL eMPLEADO_POR_ROL = db.EMPLEADO_POR_ROL.Find(idRol,idEmpleado);
            if (eMPLEADO_POR_ROL == null)
            {
                return NotFound();
            }
            eMPLEADO_POR_ROL.Estado = "I"; //Deletion
            db.Entry(eMPLEADO_POR_ROL).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADO_POR_ROLExists(idRol, idEmpleado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(eMPLEADO_POR_ROL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADO_POR_ROLExists(byte idRol, int idEmpleado)
        {
            return db.EMPLEADO_POR_ROL.Find(idRol ,idEmpleado) != null;
        }
    }
}