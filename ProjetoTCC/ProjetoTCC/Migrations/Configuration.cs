namespace ProjetoTCC.Migrations
{
    using SistemaLocacaoHBSIS.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaLocacaoHBSIS.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextDB context)
        {
            var TipoVeiculos = new List<TipoVeiculo>() {
                new TipoVeiculo(){CodigoTipo = 0,Descricao = "Automóvel"},
                new TipoVeiculo(){CodigoTipo = 1,Descricao = "Moto"},
                new TipoVeiculo(){CodigoTipo = 2,Descricao = "Bicicleta"},
                new TipoVeiculo(){CodigoTipo = 3,Descricao = "Patinete"},
                };

            TipoVeiculos.ForEach(s => context.tipoVeiculos.AddOrUpdate(p => p.Descricao, s));
            context.SaveChanges();

            var incrementCodigoMarca = 1;

            var Marcas = new List<Marca>()
            {
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Audi"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "BMW"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Chevrolet"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Citröen"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Fiat"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Ford"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Honda"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Hyundai"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Jeep"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Kia"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Mitsubishi"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Nissan"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Peugeot"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Renault"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Toyota"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automóvel")),CodigoMarca = incrementCodigoMarca++,Descricao = "Volkswagen"},
                //                         
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Dafra"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Honda"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Suzuki"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Yamaha"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Kawasaki"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "BMW"},
                //new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Moto")),CodigoMarca = incrementCodigoMarca++,Descricao = "Ducati"},
            };

            Marcas.ForEach(s => context.marcas.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            
        }
    }
}
