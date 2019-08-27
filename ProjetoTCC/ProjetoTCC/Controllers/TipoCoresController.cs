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
    public class TipoCoresController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/TipoCores
        public IQueryable<TipoCor> GettipoCores()
        {
            return db.tipoCores;
        }

        // GET: api/TipoCores/5
        [ResponseType(typeof(TipoCor))]
        public async Task<IHttpActionResult> GetTipoCor(int id)
        {
            TipoCor tipoCor = await db.tipoCores.FindAsync(id);
            if (tipoCor == null)
            {
                return NotFound();
            }

            return Ok(tipoCor);
        }

        // PUT: api/TipoCores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTipoCor(int id, TipoCor tipoCor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tipoCor.Id)
            {
                return BadRequest();
            }

            db.Entry(tipoCor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoCorExists(id))
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

        // POST: api/TipoCores
        [ResponseType(typeof(TipoCor))]
        public async Task<IHttpActionResult> PostTipoCor(TipoCor tipoCor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tipoCores.Add(tipoCor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = tipoCor.Id }, tipoCor);
        }

        // DELETE: api/TipoCores/5
        [ResponseType(typeof(TipoCor))]
        public async Task<IHttpActionResult> DeleteTipoCor(int id)
        {
            TipoCor tipoCor = await db.tipoCores.FindAsync(id);
            if (tipoCor == null)
            {
                return NotFound();
            }

            db.tipoCores.Remove(tipoCor);
            await db.SaveChangesAsync();

            return Ok(tipoCor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TipoCorExists(int id)
        {
            return db.tipoCores.Count(e => e.Id == id) > 0;
        }
    }
}