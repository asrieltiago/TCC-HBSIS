using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class MarcaAutomovel : UserControls
    {
        [Key]
        public int IdMarca { get; set; }        
        public string Descricao { get; set; }        

    }
}