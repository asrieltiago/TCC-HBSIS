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
        public DbSet<MarcaAutomovel> marcaAutomoveis { get; set; }
        public DbSet<MarcaMoto> marcaMotos { get; set; }
        public DbSet<ModeloAutomovel> modeloAutomoveis { get; set; }
        public DbSet<ModeloMoto> modeloMotos { get; set; }
        public DbSet<Periodo> periodos { get; set; }
        public DbSet<RegistroVeiculo> registrosVeiculos { get; set; }
        public DbSet<TermoLocacao> termoLocacatermoLocacoeso { get; set; }
        public DbSet<TipoCor> tipoCores { get; set; }
        public DbSet<TipoVeiculo> tipoVeiculos { get; set; }
    }
}