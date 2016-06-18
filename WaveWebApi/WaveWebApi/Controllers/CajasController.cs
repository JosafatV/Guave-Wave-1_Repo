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
    public class CajasController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        [HttpGet]
        [Route("api/Cajas")]
        public IQueryable<CAJA> GetCAJA()
        {
            return db.CAJA.Where(T => T.Estado == "A");
        }

        [HttpGet]
        [Route("api/Cajas/{id}")]
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult GetCAJA(int id)
        {
            CAJA cAJA = db.CAJA.Find(id);
            if (cAJA == null || cAJA.Estado != "A")
            {
                return NotFound();
            }

            return Ok(cAJA);
        }

        [HttpPut]
        [Route("api/Cajas/{id}")]
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult PutCAJA(int id, CAJA cAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cAJA.IdCaja)
            {
                return BadRequest();
            }

            db.Entry(cAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cAJA);
        }

        [HttpPut]
        [Route("api/Cajas/Cierre/{idCaja}/{DineroCierre}")]
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult CierreCAJA(int idCaja, decimal DineroCierre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            db.sp_CierreDeCaja(idCaja,DineroCierre);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJAExists(idCaja))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(db.CAJA.Find(idCaja));
        }

        [HttpPost]
        [Route("api/Cajas")]
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult PostCAJA(CAJA cAJA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAJA.Add(cAJA);
            db.SaveChanges();

            return Ok(cAJA);
        }

        [HttpDelete]
        [Route("api/Cajas/{id}")]
        [ResponseType(typeof(CAJA))]
        public IHttpActionResult DeleteCAJA(int id)
        {
            CAJA cAJA = db.CAJA.Find(id);
            if (cAJA == null)
            {
                return NotFound();
            }

            cAJA.Estado = "I";
            db.Entry(cAJA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cAJA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAJAExists(int id)
        {
            return db.CAJA.Count(e => e.IdCaja == id) > 0;
        }

        [HttpOptions]
        [Route("api/Cajas/{id}")]
        [Route("api/Cajas")]
        [Route("api/Cajas/Cierre/{idCaja}/{DineroCierre}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}