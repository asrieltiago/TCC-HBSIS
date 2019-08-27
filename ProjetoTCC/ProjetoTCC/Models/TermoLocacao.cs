using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    [Table("TermoLocacoes")]
    public class TermoLocacao : UserControls
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10000,ErrorMessage = "O Texto supera o limite de 10.000 caracteres.")]
        public string Termo { get; set; }
    }
}