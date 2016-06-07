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
    public class RolesController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/Roles
        public IQueryable<ROL> GetROL()
        {
            return db.ROL;
        }

        // GET: api/Roles/5
        [ResponseType(typeof(ROL))]
        public IHttpActionResult GetROL(byte id)
        {
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return NotFound();
            }

            return Ok(rOL);
        }

        // PUT: api/Roles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutROL(byte id, ROL rOL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rOL.IdRol)
            {
                return BadRequest();
            }

            db.Entry(rOL).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ROLExists(id))
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

        // POST: api/Roles
        [ResponseType(typeof(ROL))]
        public IHttpActionResult PostROL(ROL rOL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ROL.Add(rOL);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = rOL.IdRol }, rOL);
        }

        // DELETE: api/Roles/5
        [ResponseType(typeof(ROL))]
        public IHttpActionResult DeleteROL(byte id)
        {
            ROL rOL = db.ROL.Find(id);
            if (rOL == null)
            {
                return NotFound();
            }

            db.ROL.Remove(rOL);
            db.SaveChanges();

            return Ok(rOL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ROLExists(byte id)
        {
            return db.ROL.Count(e => e.IdRol == id) > 0;
        }
    }
}