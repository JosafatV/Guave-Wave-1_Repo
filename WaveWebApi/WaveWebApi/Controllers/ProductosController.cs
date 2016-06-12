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
    public class ProductosController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();

        
        [HttpGet]
        [Route("api/Productos")]
        public IQueryable<PRODUCTO> GetPRODUCTO()
        {
            return db.PRODUCTO.Where(T => T.Estado == "A"); 
        }

       
        [HttpGet]
        [Route("api/Productos/{id}")]
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult GetPRODUCTO(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null || pRODUCTO. Estado != "A")
            {
                return NotFound();
            }

            return Ok(pRODUCTO);
        }

        [HttpPut]
        [Route("api/Productos/{id}")]
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult PutPRODUCTO(int id, PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pRODUCTO.IdProducto)
            {
                return BadRequest();
            }

            db.Entry(pRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pRODUCTO);
        }

       
        [HttpPost]
        [Route("api/Productos")]
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult PostPRODUCTO(PRODUCTO pRODUCTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PRODUCTO.Add(pRODUCTO);
            db.SaveChanges();

            return Ok(pRODUCTO);
        }


        [HttpDelete]
        [Route("api/Productos/{id}")]
        [ResponseType(typeof(PRODUCTO))]
        public IHttpActionResult DeletePRODUCTO(int id)
        {
            PRODUCTO pRODUCTO = db.PRODUCTO.Find(id);
            if (pRODUCTO == null)
            {
                return NotFound();
            }

            pRODUCTO.Estado = "I";
            db.Entry(pRODUCTO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PRODUCTOExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(pRODUCTO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PRODUCTOExists(int id)
        {
            return db.PRODUCTO.Count(e => e.IdProducto == id) > 0;
        }

        [HttpOptions]
        [Route("api/Productos")]
        [Route("api/Productos/{id}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}