namespace Cyclone
{
	public static class WeatherApi
	{
		public static HttpClient client;
		public static WeatherModel weather;

		public static void InitaliseClient()
		{
			client = new HttpClient();
        }
	}
}

