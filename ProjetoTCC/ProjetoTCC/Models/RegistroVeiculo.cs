using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class RegistroVeiculo : UserControls
    {
        [Key]
        public int IdRegistro { get; set; }

        public string Placa { get; set; }

        [ForeignKey("IdModelo")]
        public Modelo Modelo { get; set; }
        public int IdModelo { get; set; }

        [ForeignKey("IdCor")]
        public TipoCor Cor { get; set; }
        public int IdCor { get; set; }

    }
}