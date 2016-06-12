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
    public class EmpleadosController : ApiController
    {
        private PosPFEntities db = new PosPFEntities();
        /// <summary>
        /// Es para ver todos los emplados con roles que existen
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Empleados")]
        public IQueryable<View_EmpleadoPorRol> GetEmpladosPorRol()
        {
            return db.View_EmpleadoPorRol;
        }
 
        /// <summary>
        /// Busca un emplado por su rol y por su idRol
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <param name="idRol"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Empleado/{idEmpleado}/{idRol}")]
        [ResponseType(typeof(View_EmpleadoPorRol))]
        public IHttpActionResult GetEMPLEADO_POR_ROL(int idEmpleado, int idRol)
        {
            View_EmpleadoPorRol Empleado = db.View_EmpleadoPorRol.
                SqlQuery("Select * from View_EmpleadoPorRol where idEmpleado = '" + idEmpleado + "' and idRol = '" + idRol + "' ").ToList().First();
            if (Empleado == null)
            {
                return NotFound();
            }

            return Ok(Empleado);
        }

        [HttpGet]
        [Route("api/EmpleadoLogIn/{idEmpleado}/{password}")]
        [ResponseType(typeof(List<View_EmpleadoPorRol>))]
        public IHttpActionResult GetEmpleadoLogin(int idEmpleado, int password)
        {
            List<View_EmpleadoPorRol> List_Empleado = db.View_EmpleadoPorRol.
                SqlQuery("Select * from View_EmpleadoPorRol where idEmpleado = '" + idEmpleado + "' and contrasena = '" + password + "' ").ToList();
            if (List_Empleado == null || List_Empleado.Count == 0)
            {
                return NotFound();
            }

            return Ok(List_Empleado);
        }

        /// <summary>
        /// Agrega un empleado con un rol 
        /// </summary>
        /// <param name="empleado"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/Empleado")]
        [ResponseType(typeof(View_EmpleadoPorRol))]
        public IHttpActionResult PostEMPLEADO(View_EmpleadoPorRol empleado)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            string contrasenia= empleado.Contrasena;
            string cedula= empleado.Cedula;
            string nombre= empleado.Nombre;
            string apellidos = empleado.Apellidos;
            byte Rol= empleado.IdRol;
            //calls an insert stored procedure and returns the new id
            empleado.IdEmpleado=  db.sp_insert_Empleado(contrasenia,cedula , nombre ,apellidos , Rol); 
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Empleado_Por_Rol_Exists(empleado.IdEmpleado))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(empleado);
        }

        /// <summary>
        /// Es para agregarle más roles a un empleado
        /// </summary>
        /// <param name="empleadoPorRol"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/EmpleadoPorRol")]
        [ResponseType(typeof(View_EmpleadoPorRol))]
        public IHttpActionResult PostEmpladoPorRol(EMPLEADO_POR_ROL empleadoPorRol)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.EMPLEADO_POR_ROL.Add(empleadoPorRol);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if ( GetEMPLEADO_POR_ROL(empleadoPorRol.IdEmpleado, empleadoPorRol.IdRol) != NotFound())
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return Ok(empleadoPorRol);
        }

        /// <summary>
        /// Borra la relación Emplado por rol
        /// </summary>
        /// <param name="idRol"></param>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/EmpleadoPorRol/{idRol}/{idEmpleado}")]
        [ResponseType(typeof(EMPLEADO_POR_ROL))]
        public IHttpActionResult DeleteEMPLEADO_POR_ROL(byte idRol, int idEmpleado)
        {
            EMPLEADO_POR_ROL eMPLEADO_POR_ROL = db.EMPLEADO_POR_ROL.Find(idRol, idEmpleado);
            if (eMPLEADO_POR_ROL == null)
            {
                return NotFound();
            }
            eMPLEADO_POR_ROL.Estado = "I"; //Deletion
            db.Entry(eMPLEADO_POR_ROL).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Empleado_Por_Rol_Exists( idEmpleado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(eMPLEADO_POR_ROL);
        }
        /// <summary>
        /// Borra un Empleado
        /// </summary>
        /// <param name="idEmpleado"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("api/Empleado/{idEmpleado}")]
        [ResponseType(typeof(EMPLEADO))]
        public IHttpActionResult DeleteEmpleado( int idEmpleado)
        {
            EMPLEADO empleado = db.EMPLEADO.Find(idEmpleado);
            if (empleado == null)
            {
                return NotFound();
            }
            empleado.Estado = "I"; //Deletion
            db.Entry(empleado).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(idEmpleado))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(empleado);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Empleado_Por_Rol_Exists( int idEmpleado)
        {
            return db.EMPLEADO_POR_ROL.Find(idEmpleado) != null;
        }
        private bool EmpleadoExists(int idEmpleado)
        {
            return db.EMPLEADO.Find(idEmpleado) != null;
        }


        [HttpOptions]
        [Route("api/Empleado")]
        [Route("api/EmpleadoPorRol")]
        [Route("api/EmpleadoPorRol/{idRol}/{idEmpleado}")]
        [Route("api/Empleado/{idEmpleado}")]
        public HttpResponseMessage Options()
        {
            return new HttpResponseMessage { StatusCode = HttpStatusCode.OK };
        }
    }
}