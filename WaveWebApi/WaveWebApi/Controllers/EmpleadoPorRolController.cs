﻿using System;
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
        public IQueryable<EMPLEADO_POR_ROL> GetEMPLEADO_POR_ROL()
        {
            return db.EMPLEADO_POR_ROL;
        }

        // GET: api/EmpleadoPorRol/5
        [ResponseType(typeof(EMPLEADO_POR_ROL))]
        public IHttpActionResult GetEMPLEADO_POR_ROL(byte id)
        {
            EMPLEADO_POR_ROL eMPLEADO_POR_ROL = db.EMPLEADO_POR_ROL.Find(id);
            if (eMPLEADO_POR_ROL == null)
            {
                return NotFound();
            }

            return Ok(eMPLEADO_POR_ROL);
        }

        // PUT: api/EmpleadoPorRol/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEMPLEADO_POR_ROL(byte id, EMPLEADO_POR_ROL eMPLEADO_POR_ROL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eMPLEADO_POR_ROL.IdRol)
            {
                return BadRequest();
            }

            db.Entry(eMPLEADO_POR_ROL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EMPLEADO_POR_ROLExists(id))
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
                if (EMPLEADO_POR_ROLExists(eMPLEADO_POR_ROL.IdRol))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = eMPLEADO_POR_ROL.IdRol }, eMPLEADO_POR_ROL);
        }

        // DELETE: api/EmpleadoPorRol/5
        [ResponseType(typeof(EMPLEADO_POR_ROL))]
        public IHttpActionResult DeleteEMPLEADO_POR_ROL(byte id)
        {
            EMPLEADO_POR_ROL eMPLEADO_POR_ROL = db.EMPLEADO_POR_ROL.Find(id);
            if (eMPLEADO_POR_ROL == null)
            {
                return NotFound();
            }

            db.EMPLEADO_POR_ROL.Remove(eMPLEADO_POR_ROL);
            db.SaveChanges();

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

        private bool EMPLEADO_POR_ROLExists(byte id)
        {
            return db.EMPLEADO_POR_ROL.Count(e => e.IdRol == id) > 0;
        }
    }
}