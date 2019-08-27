using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }       
        public string Descricao { get; set; }

        [ForeignKey("CodigoTipo")]
        public TipoVeiculo Tipo { get; set; }
        public int CodigoTipo { get; set; }
    }
}