using SistemaLocacaoHBSIS.Enums;
using SistemaLocacaoHBSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProjetoTCC.Controllers
{
    public class CustomQuerysController : ApiController
    {
        private ContextDB db = new ContextDB();

        [Route("Api/Marcas/{id}/Tipo")]
        [HttpGet]
        public IQueryable<Marca> GetMarcaPorTipo(int id)
        {
            return db.marcas.Where(x => x.TipoVeiculo.Codigo == id);
        }

        [Route("Api/Modelos/{id}/Marca")]
        [HttpGet]
        public IQueryable<Modelo> GetModeloPorMarca(int id)
        {
            return db.modelos.Where(x => x.Marca.Codigo == id);
        }

        [Route("Api/Periodos/{id}/Tipo")]
        [HttpGet]
        public IQueryable<Periodo> GetPeriodosPorMarcaVigentes(int id)
        {
            return db.periodos.Where(x => x.TipoVeiculo.Codigo == id && DateTime.Now <= x.DataFinal);
        }


        [ResponseType(typeof(Locacao))]
        [AcceptVerbs("PATCH")]
        [Route("api/Locacoes/{codLocacao}/{idStatus}")]
        public IHttpActionResult AprovaLocacao(int codLocacao, int idStatus)
        {
            Locacao locacao = db.locacoes.Find(codLocacao);
            if (locacao == null)
            {
                return NotFound();
            }
            switch (idStatus)
            {
                case 1: locacao.Status = StatusLocacao.VIGENTE; break;
                case 3: locacao.Status = StatusLocacao.FILA_DE_ESPERA; break;
            };
        
            // locacao.Situacao = Status.FILA_DE_ESPERA;
        
            db.SaveChanges();
        
            return Ok(locacao);
        }
    }
}