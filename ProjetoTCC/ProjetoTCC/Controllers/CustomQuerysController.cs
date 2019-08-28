using SistemaLocacaoHBSIS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

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
    }
}