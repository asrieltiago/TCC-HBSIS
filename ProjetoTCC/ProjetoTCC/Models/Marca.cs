using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("Marcas")]
    public class Marca
    {
        [Key]
        public int Id { get; set; }       
        public int Codigo { get; set; }
        public string Descricao { get; set; }

        //[ForeignKey("IdTipoVeiculo")]
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        //public int IdTipoVeiculo { get; set; }


    }
}