using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("TipoVeiculos")]
    public class TipoVeiculo
    {     
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }        
        public string Descricao { get; set; }       
    }   
}