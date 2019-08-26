using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ExercicioFinalWebApi.Models
{
    public class VerificarCep : Cliente
    {
        static async Task VerificaCep(string[] args, object value, Cliente clientCep, Cliente clientCidade, Cliente clientEstado, Cliente clientEndereco)
        {

            var cepClient = RestService.For<ICepApiService>("https://viacep.com.br");
            
            string meuCep = value.ToString();

            var address = await cepClient.GetAddressAsync(meuCep);

            if (clientCep != null)
            {
                address.Cidade = clientCidade.ToString();
                address.Endereco = clientEndereco.ToString();
                address.Estado = clientEstado.ToString();
                address.Cep = clientCep.ToString();
            }

            else
            {
                
            }
        }

        
    }
}