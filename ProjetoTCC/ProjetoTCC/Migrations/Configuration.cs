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
                new TipoVeiculo(){Codigo = 0,Descricao = "Automóvel"},
                new TipoVeiculo(){Codigo = 1,Descricao = "Moto"},
                new TipoVeiculo(){Codigo = 2,Descricao = "Bicicleta"},
                new TipoVeiculo(){Codigo = 3,Descricao = "Patinete"},
                };

            TipoVeiculos.ForEach(s => context.tipoVeiculos.AddOrUpdate(p => p.Descricao, s));
            context.SaveChanges();

            var incrementCodigo = 1;

            var Marcas = new List<Marca>()
            {

                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Audi"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Chevrolet"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Citröen"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Fiat"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Ford"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Honda"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Hyundai"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "BMW"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Jeep"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Kia"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Mitsubishi"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Nissan"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Peugeot"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Renault"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Toyota"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Automóvel") , Codigo = incrementCodigo++,Descricao = "Volkswagen"},
                                         
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Dafra"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Honda"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Suzuki"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Yamaha"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Kawasaki"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "BMW"},
                new Marca(){TipoVeiculo = TipoVeiculos.Single(x => x.Descricao == "Moto") , Codigo = incrementCodigo++,Descricao = "Ducati"},
            };

            Marcas.ForEach(s => context.marcas.AddOrUpdate(p => p.Id, s));
            context.SaveChanges();
            
        }
    }
}
