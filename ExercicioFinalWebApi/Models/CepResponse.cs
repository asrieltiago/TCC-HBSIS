using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExercicioFinalWebApi.Models
{
    public class CepResponse
    {
        [JsonProperty(PropertyName = "cep")]
        public string Cep { get; set; }

        [JsonProperty(PropertyName = "logradouro")]
        public string Endereco { get; set; }

        [JsonProperty(PropertyName = "localidade")]
        public string Cidade { get; set; }

        [JsonProperty(PropertyName = "uf")]
        public string Estado { get; set; }
    }
}