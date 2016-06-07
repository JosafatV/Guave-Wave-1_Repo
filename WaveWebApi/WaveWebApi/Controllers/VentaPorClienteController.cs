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
    public class VentaPorClienteController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/VentaPorCliente
        public IQueryable<VENTA_POR_CLIENTE> GetVENTA_POR_CLIENTE()
        {
            return db.VENTA_POR_CLIENTE;
        }

        // GET: api/VentaPorCliente/5
        [ResponseType(typeof(VENTA_POR_CLIENTE))]
        public IHttpActionResult GetVENTA_POR_CLIENTE(int id)
        {
            VENTA_POR_CLIENTE vENTA_POR_CLIENTE = db.VENTA_POR_CLIENTE.Find(id);
            if (vENTA_POR_CLIENTE == null)
            {
                return NotFound();
            }

            return Ok(vENTA_POR_CLIENTE);
        }

        // PUT: api/VentaPorCliente/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTA_POR_CLIENTE(int id, VENTA_POR_CLIENTE vENTA_POR_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTA_POR_CLIENTE.IdVenta)
            {
                return BadRequest();
            }

            db.Entry(vENTA_POR_CLIENTE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTA_POR_CLIENTEExists(id))
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

        // POST: api/VentaPorCliente
        [ResponseType(typeof(VENTA_POR_CLIENTE))]
        public IHttpActionResult PostVENTA_POR_CLIENTE(VENTA_POR_CLIENTE vENTA_POR_CLIENTE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VENTA_POR_CLIENTE.Add(vENTA_POR_CLIENTE);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VENTA_POR_CLIENTEExists(vENTA_POR_CLIENTE.IdVenta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vENTA_POR_CLIENTE.IdVenta }, vENTA_POR_CLIENTE);
        }

        // DELETE: api/VentaPorCliente/5
        [ResponseType(typeof(VENTA_POR_CLIENTE))]
        public IHttpActionResult DeleteVENTA_POR_CLIENTE(int id)
        {
            VENTA_POR_CLIENTE vENTA_POR_CLIENTE = db.VENTA_POR_CLIENTE.Find(id);
            if (vENTA_POR_CLIENTE == null)
            {
                return NotFound();
            }

            db.VENTA_POR_CLIENTE.Remove(vENTA_POR_CLIENTE);
            db.SaveChanges();

            return Ok(vENTA_POR_CLIENTE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTA_POR_CLIENTEExists(int id)
        {
            return db.VENTA_POR_CLIENTE.Count(e => e.IdVenta == id) > 0;
        }
    }
}