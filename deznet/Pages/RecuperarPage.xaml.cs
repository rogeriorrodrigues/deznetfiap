using System;
using System.Collections.Generic;
using Acr.UserDialogs;

using Xamarin.Forms;

namespace deznet
{
	public partial class RecuperarPage : ContentPage
	{
		public RecuperarPage()
		{
			InitializeComponent();
		}

		void Handle_Clicked(object sender, System.EventArgs e)
		{
			UserDialogs.Instance.ShowSuccess("Senha enviada para: " + txtRecuperar.Text);
		}

		async void cancelarClick(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
