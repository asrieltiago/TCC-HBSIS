using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class ModeloAutomovel : UserControls
    {
        [Key]
        public int IdModelo { get; set; }
        public string Descricao { get; set; }   
        [ForeignKey("IdMarca")]
        public MarcaAutomovel Marca { get; set; }
        public int IdMarca { get; set; }
    }
}