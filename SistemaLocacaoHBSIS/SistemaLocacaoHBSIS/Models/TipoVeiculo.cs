using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class TipoVeiculo : UserControls
    {     
        [Key]
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        
      
    }   
}