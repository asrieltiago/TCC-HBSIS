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
    public class LocacoesController : ApiController
    {
        private ContextDB db = new ContextDB();

        // GET: api/Locacoes
        public IQueryable<Locacao> Getlocacoes()
        {
            return db.locacoes;
        }

        // GET: api/Locacoes/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> GetLocacao(int id)
        {
            Locacao locacao = await db.locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            return Ok(locacao);
        }

        // PUT: api/Locacoes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLocacao(int id, Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != locacao.Id)
            {
                return BadRequest();
            }

            db.Entry(locacao).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocacaoExists(id))
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

        // POST: api/Locacoes
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> PostLocacao(Locacao locacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tipo = db.tipoVeiculos.FirstOrDefault(x => x.Codigo == locacao.TipoVeiculo.Codigo);
            var modelo = db.modelos.FirstOrDefault(x => x.Id == locacao.Modelo.Id);
            var colaborador = db.colaboradores.FirstOrDefault(x => x.Id == locacao.Colaborador.Id);
            var periodo = db.periodos.FirstOrDefault(x => x.Id == locacao.Periodo.Id);
            var cor = db.tipoCores.FirstOrDefault(x => x.Id == locacao.Cor.Id);
            var termo = db.termoLocacoes.FirstOrDefault(x => x.Id == locacao.TermoLocacao.Id);

            //if (tipo == null || modelo == null || colaborador == null || periodo == null || cor == null || termo == null)
            //    return BadRequest("Existem campos inválidos em branco, favor verificar.");

            locacao.TipoVeiculo = tipo;
            locacao.Modelo = modelo;
            locacao.Colaborador = colaborador;
            locacao.Periodo = periodo;
            locacao.Cor = cor;
            locacao.TermoLocacao = termo;

            db.locacoes.Add(locacao);
            await db.SaveChangesAsync();

            return Ok("Cadastro realizado.");
            //return CreatedAtRoute("DefaultApi", new { id = locacao.Id }, locacao);
        }

        // DELETE: api/Locacoes/5
        [ResponseType(typeof(Locacao))]
        public async Task<IHttpActionResult> DeleteLocacao(int id)
        {
            Locacao locacao = await db.locacoes.FindAsync(id);
            if (locacao == null)
            {
                return NotFound();
            }

            db.locacoes.Remove(locacao);
            await db.SaveChangesAsync();

            return Ok(locacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LocacaoExists(int id)
        {
            return db.locacoes.Count(e => e.Id == id) > 0;
        }
    }
}