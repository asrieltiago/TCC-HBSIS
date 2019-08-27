namespace SistemaLocacaoHBSIS.Migrations
{
    using SistemaLocacaoHBSIS.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<SistemaLocacaoHBSIS.Models.ContextDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ContextDB context)
        {
            var TipoVeiculos = new List<TipoVeiculo>() {
                new TipoVeiculo(){CodigoTipo = 0,Descricao = "Automovel"},
                new TipoVeiculo(){CodigoTipo = 1,Descricao = "Moto"},
                new TipoVeiculo(){CodigoTipo = 2,Descricao = "Bicicleta"},
                new TipoVeiculo(){CodigoTipo = 3,Descricao = "Patinete"},
                };

            TipoVeiculos.ForEach(s => context.tipoVeiculos.AddOrUpdate(p => p.Descricao, s));
            context.SaveChanges();

            var incrementIdMarca = 1;

            var Marcas = new List<Marca>()
            {
                new Marca(){CodigoTipo = Convert.ToInt32(TipoVeiculos.Single(x => x.Descricao == "Automovel")),IdMarca = incrementIdMarca++,Descricao = "Audi"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "BMW"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Chevrolet"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Citröen"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Fiat"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Ford"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Honda"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Hyundai"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Jeep"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Kia"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Mitsubishi"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Nissan"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Peugeot"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Renault"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Toyota"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Automovel"),IdMarca = incrementIdMarca++,Descricao = "Volkswagen"},

                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Dafra"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Honda"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Suzuki"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Yamaha"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Kawasaki"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "BMW"},
                //new Marca(){CodigoTipo = TipoVeiculos.Single(x => x.Descricao == "Moto"),IdMarca = incrementIdMarca++,Descricao = "Ducati"},
            };

            Marcas.ForEach(s => context.marcas.AddOrUpdate(p => p.IdMarca, s));
            context.SaveChanges();
        }
    }
}
