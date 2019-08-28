using SistemaLocacaoHBSIS.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjetoTCC.Models
{
    public class CustomQuerys
    {
        public string connectionString = ".\\MSSQLLocalDB;Initial Catalog = SistemaLocacaoHBSIS.Models.ContextDB; Integrated Security = True";
        public void InativarTermo(TermoLocacao termo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand("", connection))
            {
                command.CommandText = "UPDATE TermoLocacoes SET Ativo = false WHERE Ativo = true";
                
                command.ExecuteNonQuery();
            }
        }
        
    }
}