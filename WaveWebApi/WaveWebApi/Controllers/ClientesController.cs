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
    public class ClientesController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        [Route("api/Clientes")]
        [HttpGet]
        public IQueryable<CLIENTE> GetCLIENTE()
        {
            return db.CLIENTE.Where(T => T.Estado == "A");
        }

        // GET: api/Clientes/5
        [HttpGet]
        [Route("api/Clientes/{id}")]
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult GetClienteById(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null || cLIENTE.Estado != "A" )
            {
                return NotFound();
            }

            return Ok(cLIENTE);
        }

        [HttpPut]
        [Route("api/Clientes/{id}")]
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult PutCLIENTE(int id, CLIENTE cLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cLIENTE.IdCliente)
            {
                return BadRequest();
            }

            db.Entry(cLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cLIENTE);
        }

        [Route("api/Clientes")]
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult PostCLIENTE(CLIENTE cLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CLIENTE.Add(cLIENTE);
            db.SaveChanges();

            return Ok(cLIENTE);
        }

        [Route("api/Clientes/{id}")]
        [ResponseType(typeof(CLIENTE))]
        public IHttpActionResult DeleteCLIENTE(int id)
        {
            CLIENTE cLIENTE = db.CLIENTE.Find(id);
            if (cLIENTE == null)
            {
                return NotFound();
            }

            cLIENTE.Estado = "I";
            db.Entry(cLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CLIENTEExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(cLIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CLIENTEExists(int id)
        {
            return db.CLIENTE.Count(e => e.IdCliente == id) > 0;
        }

        [HttpOptions]
        [Route("api/Clientes")]
        [Route("api/Clientes/{id}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}