using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class ModeloMoto : UserControls
    {
        [Key]
        public int IdModelo { get; set; }
        public string Descricao { get; set; }
        public int Marca { get; set; }
    }
}