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
    public class SucursalesController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/Sucursales
        public IQueryable<SUCURSAL> GetSUCURSAL()
        {
            return db.SUCURSAL;
        }

        // GET: api/Sucursales/5
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult GetSUCURSAL(int id)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(sUCURSAL);
        }

        // PUT: api/Sucursales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSUCURSAL(int id, SUCURSAL sUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sUCURSAL.IdSucursal)
            {
                return BadRequest();
            }

            db.Entry(sUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SUCURSALExists(id))
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

        // POST: api/Sucursales
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult PostSUCURSAL(SUCURSAL sUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SUCURSAL.Add(sUCURSAL);
            db.SaveChanges();

            return Ok(sUCURSAL);
        }

        // DELETE: api/Sucursales/5
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult DeleteSUCURSAL(int id)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(id);
            if (sUCURSAL == null)
            {
                return NotFound();
            }

            sUCURSAL.Estado = "I"; //deletion
            db.Entry(sUCURSAL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SUCURSALExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(sUCURSAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SUCURSALExists(int id)
        {
            return db.SUCURSAL.Count(e => e.IdSucursal == id) > 0;
        }
    }
}