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
    public class EmpleadosController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/Empleados
        public IQueryable<EMPLEADO> GetEMPLEADO()
        {
            return db.EMPLEADO;
        }

        // GET: api/Empleados/5
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult GetEMPLEADO(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO);
        }

        // PUT: api/Empleados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLEADO(int id, EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADO.IdEmpleado)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADOExists(id))
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

        // POST: api/Empleados
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult PostEMPLEADO(EMPLEADO eMPLEADO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EMPLEADO.Add(eMPLEADO);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = eMPLEADO.IdEmpleado }, eMPLEADO);
        }

        // DELETE: api/Empleados/5
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult DeleteEMPLEADO(int id)
        {
            EMPLEADO eMPLEADO = db.EMPLEADO.Find(id);
            if (eMPLEADO == null)
            {
                return NotFound();
            }

            db.EMPLEADO.Remove(eMPLEADO);
            db.SaveChanges();

            return Ok(eMPLEADO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EMPLEADOExists(int id)
        {
            return db.EMPLEADO.Count(e => e.IdEmpleado == id) > 0;
        }
    }
}