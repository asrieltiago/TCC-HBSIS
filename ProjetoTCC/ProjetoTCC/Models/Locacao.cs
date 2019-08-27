using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class Locacao : UserControls
    {
        [Key]
        public int IdLocacao { get; set; }        

        [ForeignKey("IdTipo")]
        public TipoVeiculo IdTipoVeiculo { get; set; }
        public int IdTipo { get; set; }

        [ForeignKey("IdRegistro")]
        public RegistroVeiculo IdRegistroVeiculo { get; set; }
        public int IdRegistro { get; set; }

        [ForeignKey("IdColaborador")]
        public Colaborador Colaborador { get; set; }
        public int IdColaborador { get; set; }

        [ForeignKey("IdPeriodo")]
        public Periodo Periodo { get; set; }
        public int IdPeriodo { get; set; }

        [ForeignKey("IdTermo")]
        public TermoLocacao TermoLocacao { get; set; }
        public int IdTermo { get; set; }

        public bool AceiteTermo { get; set; }

        public Enums.StatusLocacao Status { get; set; }

    }
}