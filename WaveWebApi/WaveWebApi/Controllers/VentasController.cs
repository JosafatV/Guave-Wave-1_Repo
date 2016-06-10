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
    public class VentasController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

       
        [HttpGet]
        [Route("api/VentasPorCaja")]
        public IQueryable<View_VentaPorCaja> GetVentaPorCaja()
        {
            return db.View_VentaPorCaja;
        }
      
        [HttpGet]
        [Route("api/VentasPorCliente")]
        public IQueryable<View_VentaPorCliente> GetVentaPorCliente()
        {
            return db.View_VentaPorCliente;
        }

       /* // GET: api/Ventas/5
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult GetVENTA(int id)
        {
            VENTA vENTA = db.VENTA.Find(id);
            if (vENTA == null)
            {
                return NotFound();
            }

            return Ok(vENTA);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVENTA(int id, VENTA vENTA)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vENTA.IdVenta)
            {
                return BadRequest();
            }

            db.Entry(vENTA).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTAExists(id))
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
        */
       
        [ResponseType(typeof(void))]
        [Route("api/Ventas")]
        public void PostVenta(int IdCaja, int IdCliente)
        {
            if (!ModelState.IsValid)
            {
               // return BadRequest(ModelState);
            }
            int idVenta = db.sp_insert_Venta(IdCaja, IdCliente);
            db.SaveChanges();

            //return Ok(IdCaja);
        }

        [HttpDelete]
        [Route("api/Ventas/{idVenta}")]
        [ResponseType(typeof(VENTA))]
        public IHttpActionResult DeleteVENTA(int idVenta)
        {
            VENTA vENTA = db.VENTA.Find(idVenta);
            if (vENTA == null)
            {
                return NotFound();
            }

            vENTA.Estado = "I"; //Deletion

            db.Entry(vENTA).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VENTAExists(idVenta))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(vENTA);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VENTAExists(int id)
        {
            return db.VENTA.Count(e => e.IdVenta == id) > 0;
        }

        [HttpOptions]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}