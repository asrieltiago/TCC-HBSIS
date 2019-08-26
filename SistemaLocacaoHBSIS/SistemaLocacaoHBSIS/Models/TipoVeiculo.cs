using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class TipoVeiculo : UserControls
    {
        public int Automovel { get; set;}
        public int Moto { get; set; }
        public int Bicicleta { get; set; }
        public int Patinete { get; set; }
    }
}