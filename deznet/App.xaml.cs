using Xamarin.Forms;

namespace deznet
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			//Inicializar utilizando a page de login e senha
			//MainPage = new NavigationPage(new deznetPage());

			//inicialiar usando a page com Viewmodel
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
