using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaLocacaoHBSIS.Models;

namespace ProjetoTCC.Controllers
{
    public class ColaboradoresController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Colaboradores
        public IQueryable<Colaborador> Getcolaboradores()
        {
            return db.colaboradores;
        }

        // GET: api/Colaboradores/5
        [ResponseType(typeof(Colaborador))]
        public async Task<IHttpActionResult> GetColaborador(int id)
        {
            Colaborador colaborador = await db.colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            return Ok(colaborador);
        }

        // PUT: api/Colaboradores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutColaborador(int id, Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != colaborador.Id)
            {
                return BadRequest();
            }

            db.Entry(colaborador).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColaboradorExists(id))
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

        // POST: api/Colaboradores
        [ResponseType(typeof(Colaborador))]
        public async Task<IHttpActionResult> PostColaborador(Colaborador colaborador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.colaboradores.Add(colaborador);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = colaborador.Id }, colaborador);
        }

        // DELETE: api/Colaboradores/5
        [ResponseType(typeof(Colaborador))]
        public async Task<IHttpActionResult> DeleteColaborador(int id)
        {
            Colaborador colaborador = await db.colaboradores.FindAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }

            db.colaboradores.Remove(colaborador);
            await db.SaveChangesAsync();

            return Ok(colaborador);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ColaboradorExists(int id)
        {
            return db.colaboradores.Count(e => e.Id == id) > 0;
        }
    }
}