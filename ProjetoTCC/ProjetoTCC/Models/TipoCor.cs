using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class TipoCor : UserControls
    {
        [Key]
        public int IdCor { get; set; }
        public string Descricao { get; set; }
    }
}