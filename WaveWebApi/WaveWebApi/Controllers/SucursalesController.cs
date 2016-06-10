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

     
        [HttpGet]
        [Route("api/Sucursales")]
        public IQueryable<SUCURSAL> GetSUCURSAL()
        {
            return db.SUCURSAL;
        }

        // GET: api/Sucursales/5
        [HttpGet]
        [Route("api/Sucursales/{idSucursal}")]
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult GetSUCURSAL(int idSucursal)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(idSucursal);
            if (sUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(sUCURSAL);
        }

        [HttpPut]
        [Route("api/Sucursales/{idSucursal}")]
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult PutSUCURSAL(int idSucursal, SUCURSAL sUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (idSucursal != sUCURSAL.IdSucursal)
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
                if (!SUCURSALExists(idSucursal))
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

        [HttpPost]
        [Route("api/Sucursales")]
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

        [HttpDelete]
        [Route("api/Sucursales/{idSucursal}")]
        [ResponseType(typeof(SUCURSAL))]
        public IHttpActionResult DeleteSUCURSAL(int idSucursal)
        {
            SUCURSAL sUCURSAL = db.SUCURSAL.Find(idSucursal);
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
                if (!SUCURSALExists(idSucursal))
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

        [HttpOptions]
        [Route("api/Sucursales/{idSucursal}")]
        [Route("api/Sucursales")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}