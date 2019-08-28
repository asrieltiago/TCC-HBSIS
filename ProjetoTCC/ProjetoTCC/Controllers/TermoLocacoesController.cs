using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using SistemaLocacaoHBSIS.Models;

namespace ProjetoTCC.Controllers
{
    public class TermoLocacoesController : ApiController
    {
        private ContextDB db = new ContextDB();      
        

        // GET: api/TermoLocacoes
        public IQueryable<TermoLocacao> GettermoLocacoes()
        {
            return db.termoLocacoes;
        }

        // GET: api/TermoLocacoes/5
        [ResponseType(typeof(TermoLocacao))]
        public async Task<IHttpActionResult> GetTermoLocacao(int id)
        {
            TermoLocacao termoLocacao = await db.termoLocacoes.FindAsync(id);
            if (termoLocacao == null)
            {
                return NotFound();
            }

            return Ok(termoLocacao);
        }

        // PUT: api/TermoLocacoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTermoLocacao(int id, TermoLocacao termoLocacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != termoLocacao.Id)
            {
                return BadRequest();
            }

            db.Entry(termoLocacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TermoLocacaoExists(id))
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

        
        // POST: api/TermoLocacoes
        [ResponseType(typeof(TermoLocacao))]
        public async Task<IHttpActionResult> PostTermoLocacao(TermoLocacao termoLocacao)
        {      
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var termo = db.termoLocacoes.FirstOrDefault(x => x.Ativo == true);
            if (termo != null)            
                termo.Ativo = false; 

            db.termoLocacoes.Add(termoLocacao);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = termoLocacao.Id }, termoLocacao);
        }

        // DELETE: api/TermoLocacoes/5
        [ResponseType(typeof(TermoLocacao))]
        public async Task<IHttpActionResult> DeleteTermoLocacao(int id)
        {
            TermoLocacao termoLocacao = await db.termoLocacoes.FindAsync(id);
            if (termoLocacao == null)
            {
                return NotFound();
            }

            db.termoLocacoes.Remove(termoLocacao);
            await db.SaveChangesAsync();

            return Ok(termoLocacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TermoLocacaoExists(int id)
        {
            return db.termoLocacoes.Count(e => e.Id == id) > 0;
        }
    }
}