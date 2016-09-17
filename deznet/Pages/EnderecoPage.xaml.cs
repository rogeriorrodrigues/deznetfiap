using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace deznet
{
	public partial class EnderecoPage : ContentPage
	{
		public EnderecoPage()
		{
			InitializeComponent();
		}



		async void Handle_Focused(object sender, Xamarin.Forms.FocusEventArgs e)
		{
			string sURL = "https://viacep.com.br/ws/{0}/json/";

			HttpClient client = new HttpClient();

			var uri = new Uri(string.Format(sURL, txtCep.Text));

			var response = await client.GetAsync(uri);

			CepResultModel cep = new CepResultModel();

			if (response.IsSuccessStatusCode)
			{
				var contet = await response.Content.ReadAsStringAsync();

				cep = JsonConvert.DeserializeObject<CepResultModel>(contet);

				txtrua.Text = cep.rua;
				txtbairro.Text = cep.bairro;
				txtcom.Text = cep.comp;
				txtcidade.Text = cep.cidade;
				txtuf.Text = cep.uf;
				numero.Focus();

				UserDialogs.Instance.ShowSuccess("Requisição OK");

			}
			else
			{
				UserDialogs.Instance.ShowError("Erro na Requisição");
			}
		}
	}
}
