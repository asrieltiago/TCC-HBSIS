using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class Locacao : UserControls
    {
        [Key]
        public int IdLocacao { get; set; }        
        public int IdTipoVeiculo { get; set; }
        public int IdRegistro { get; set; }
        public int IdColaborador { get; set; }       
        public int IdPeriodo { get; set; }
        public bool AceiteTermo { get; set; }
        public decimal Valor { get; set; }
        public Enums.StatusLocacao Status { get; set; }

    }
}