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
using CRUD_COM_WEB_API.Models;

namespace CRUD_COM_WEB_API.Controllers
{
    public class EmpregadosController : ApiController
    {
        private DBMODEL db = new DBMODEL();

        // GET: api/Empregados
        public IQueryable<Empregados> GetEmpregados()
        {
            return db.Empregados;
        }

        // GET: api/Empregados/5
        [ResponseType(typeof(Empregados))]
        public IHttpActionResult GetEmpregados(int id)
        {
            Empregados empregados = db.Empregados.Find(id);
            if (empregados == null)
            {
                return NotFound();
            }

            return Ok(empregados);
        }

        // PUT: api/Empregados/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpregados(int id, Empregados empregados)
        {

            if (id != empregados.EmpregadoID)
            {
                return BadRequest();
            }

            db.Entry(empregados).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpregadosExists(id))
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

        // POST: api/Empregados
        [ResponseType(typeof(Empregados))]
        public IHttpActionResult PostEmpregados(Empregados empregados)
        {


            db.Empregados.Add(empregados);
            db.SaveChanges();
            
            return CreatedAtRoute("DefaultApi", new { id = empregados.EmpregadoID }, empregados);
        }
        

        // DELETE: api/Empregados/5
        [ResponseType(typeof(Empregados))]
        public IHttpActionResult DeleteEmpregados(int id)
        {
            Empregados empregados = db.Empregados.Find(id);
            if (empregados == null)
            {
                return NotFound();
            }

            db.Empregados.Remove(empregados);
            db.SaveChanges();

            return Ok(empregados);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpregadosExists(int id)
        {
            return db.Empregados.Count(e => e.EmpregadoID == id) > 0;
        }
    }
}