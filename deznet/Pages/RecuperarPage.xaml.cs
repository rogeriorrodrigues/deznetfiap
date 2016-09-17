using System;
using System.Collections.Generic;

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
			DisplayAlert("Recuperar", "Senha enviada para: " + txtRecuperar.Text, "OK" );
		}

		async void cancelarClick(object sender, System.EventArgs e)
		{
			await Navigation.PopModalAsync();
		}
	}
}
