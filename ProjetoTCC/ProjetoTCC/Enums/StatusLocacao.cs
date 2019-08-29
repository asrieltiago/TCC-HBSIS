using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SistemaLocacaoHBSIS.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum StatusLocacao
    {
        [EnumMember(Value = "Vigente")]
        VIGENTE = 1,

        [EnumMember(Value = "Em Aprovação")]
        EM_APROVACAO = 2,

        [EnumMember(Value = "Fila de Espera")]
        FILA_DE_ESPERA = 3
    }
}  