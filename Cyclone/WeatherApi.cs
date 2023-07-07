

namespace Cyclone
{
	public static class WeatherApi
	{
		public static HttpClient weatherApiClient;

		static WeatherApi()
		{
			weatherApiClient = new HttpClient
			{
				BaseAddress = new Uri("https://api.weatherapi.com/v1/current.json?key=APIKeyHere&q=")
			}; // initialising new client

        }
	}
}

