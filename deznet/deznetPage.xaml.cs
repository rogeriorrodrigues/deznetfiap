using Xamarin.Forms;

namespace deznet
{
	public partial class deznetPage : ContentPage
	{
		public deznetPage()
		{
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e)
		{
			await Navigation.PushAsync(new NavigationPage(new UserTabbedPage()));
		}

		async void recuperarClick(object sender, System.EventArgs e)
		{
			await Navigation.PushModalAsync(new NavigationPage(new RecuperarPage()));
		}
	}
}
