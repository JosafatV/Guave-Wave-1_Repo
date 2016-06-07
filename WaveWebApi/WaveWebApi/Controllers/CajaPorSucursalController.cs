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
    public class CajaPorSucursalController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        // GET: api/CajaPorSucursal
        [HttpGet]
        public IQueryable<View_CajaPorSucursal> GetCAJA_POR_SUCURSAL()
        {
            return db.View_CajaPorSucursal;
        }

        // GET: api/CajaPorSucursal/5
        [HttpGet]
        [ResponseType(typeof(View_CajaPorSucursal))]
        [Route("api/CajaPorSucursal/{idCaja}/{idSucursal}")]
        public IHttpActionResult GetCAJA_POR_SUCURSAL(int idCaja, int idSucursal)
        {
            View_CajaPorSucursal cAJA_POR_SUCURSAL = db.View_CajaPorSucursal.Find(idCaja, idSucursal);
            if (cAJA_POR_SUCURSAL == null)
            {
                return NotFound();
            }

            return Ok(cAJA_POR_SUCURSAL);
        }
        // POST: api/CajaPorSucursal
        [ResponseType(typeof(CAJA_POR_SUCURSAL))]
        public IHttpActionResult PostCAJA_POR_SUCURSAL(CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CAJA_POR_SUCURSAL.Add(cAJA_POR_SUCURSAL);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CAJA_POR_SUCURSALExists(cAJA_POR_SUCURSAL.IdCaja, cAJA_POR_SUCURSAL.IdSucursal))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            //custom change
            return Ok(cAJA_POR_SUCURSAL);
        }

        // DELETE: api/CajaPorSucursal/5
        [Route("api/CajaPorSucursal/{idCaja}/{idSucursal}")]
        [ResponseType(typeof(CAJA_POR_SUCURSAL))]
        public IHttpActionResult DeleteCAJA_POR_SUCURSAL(int idCaja,int idSucursal)
        {
            CAJA_POR_SUCURSAL cAJA_POR_SUCURSAL = db.CAJA_POR_SUCURSAL.Find(idCaja,idSucursal);
            if (cAJA_POR_SUCURSAL == null)
            {
                return NotFound();
            }
            cAJA_POR_SUCURSAL.Estado = "I" ; //sets the state inactive (DELETION)
            db.Entry(cAJA_POR_SUCURSAL).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CAJA_POR_SUCURSALExists(idCaja,idSucursal))
                {
                 return NotFound();
                }
                else
                {
                throw;
                }
            }

            return Ok(cAJA_POR_SUCURSAL);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CAJA_POR_SUCURSALExists(int idCaja, int idSucursal)
        {
            return db.CAJA_POR_SUCURSAL.Find(idCaja, idSucursal) != null;
        }
    }
}