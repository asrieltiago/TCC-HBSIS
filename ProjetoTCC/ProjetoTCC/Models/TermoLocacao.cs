using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class TermoLocacao : UserControls
    {
        [Key]
        public int Id { get; set; }
        public string Termo { get; set; }
    }
}