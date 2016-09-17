using System;
using System.Collections.Generic;
using System.Net.Http;
using Plugin.Geolocator;
using Xamarin.Forms;
using Newtonsoft.Json;
using Xamarin.Forms.Maps;

namespace deznet
{
	public partial class DadosPage : ContentPage
	{
		public DadosPage()
		{
			InitializeComponent();
			geoloc();
		}

		async void geoloc()
		{
			var locator = CrossGeolocator.Current;
			locator.DesiredAccuracy = 50;


			var position = await locator.GetPositionAsync(10000);

			string testloc = position.Latitude.ToString();
			string testlat = position.Longitude.ToString();


			map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(position.Latitude, position.Longitude), Distance.FromMiles(1)));

			var pin = new Pin {
				Type = PinType.Place,
				Position = new Position(position.Latitude, position.Longitude),
				Label = "Minha localização",
				Address = "Terra do nunca"
			};

			map.Pins.Add(pin);

			string url = "http://api.geonames.org/findNearByWeatherJSON?lat=37&lng=-122&username=deznetfiap";


			HttpClient client = new HttpClient();


			var uri = new Uri(url);

			var response = await client.GetAsync(uri);

			lblLat.Text = position.Latitude.ToString();
			lblLong.Text = position.Longitude.ToString();

			TempoResultModel tempo = new TempoResultModel();

			if (response.IsSuccessStatusCode)
			{
				var contet = await response.Content.ReadAsStringAsync();

				tempo = JsonConvert.DeserializeObject<TempoResultModel>(contet);

				lblLoc.Text = tempo.weatherObservation.stationName;
				lblTemp.Text = tempo.weatherObservation.temperature;
			}

		}

	}
}
