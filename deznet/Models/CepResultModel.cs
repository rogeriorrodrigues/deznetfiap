using System;
using Newtonsoft.Json;

namespace deznet
{
	public class CepResultModel
	{
		[JsonProperty("cep")]
		public string cep { get; set; } 

		[JsonProperty("logradouro")]
		public string rua { get; set; }

		[JsonProperty("complemento")]
		public string comp { get; set; }

		[JsonProperty("bairro")]
		public string bairro { get; set; }

		[JsonProperty("localidade")]
		public string cidade { get; set; }

		[JsonProperty("uf")]
		public string uf { get; set; }

		public CepResultModel()
		{
		}
	}
}
