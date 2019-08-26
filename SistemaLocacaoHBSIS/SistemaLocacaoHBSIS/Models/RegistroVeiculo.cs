using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class RegistroVeiculo : UserControls
    {
        [Key]
        public int IdRegistro { get; set; }
        public string Placa { get; set; }
        public int Tipo { get; set; }
        public int Marca { get; set; }
        public int Modelo { get; set; }
        public int Cor { get; set; }

    }
}