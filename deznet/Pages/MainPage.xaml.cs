using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace deznet
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			/// <summary>
			/// Main page.
			/// </summary>
			BindingContext = new MainPageViewModel();
			InitializeComponent();
		}
	}
}
