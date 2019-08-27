using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SistemaLocacaoHBSIS.Models
{
    public class Colaborador
    {
        [Key]
        public int IdColaborador { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Pcd { get; set; }
        public bool TrabalhoNoturno { get; set; }
        public bool Carona { get; set; }
        public bool Idoso { get; set; }
        public bool ResideFora { get; set; }
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; } 
        

        /// <summary>
        /// Método utilizado para calcular a Idade do Colaborador com base na sua data de nascimento.
        /// </summary>
        /// <param name="DataNascimento">Data de Nascimento do Colaborador</param>
        /// <returns>Ainda sem retorno.</returns>
        //public static int CalculateIdade(DateTime DataNascimento)
        //{
        //    int anos = DateTime.Now.Year - DataNascimento.Year;
        //
        //    if (DateTime.Now.Month < DataNascimento.Month || (DateTime.Now.Month == DataNascimento.Month && DateTime.Now.Day < DataNascimento.Day))
        //
        //        anos--;
        //
        //    return anos;
        //}

    }
}