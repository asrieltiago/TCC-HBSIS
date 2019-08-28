using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class ContextDB : DbContext
    {
        public DbSet<Colaborador> colaboradores { get; set; }
        public DbSet<Locacao> locacoes { get; set; }
        public DbSet<Marca> marcas { get; set; }        
        public DbSet<Modelo> modelos { get; set; }
        public DbSet<Periodo> periodos { get; set; }
        public DbSet<TermoLocacao> termoLocacoes { get; set; }
        public DbSet<TipoCor> tipoCores { get; set; }
        public DbSet<TipoVeiculo> tipoVeiculos { get; set; }
    }
}