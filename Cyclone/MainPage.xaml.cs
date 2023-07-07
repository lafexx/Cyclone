namespace Cyclone;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		GetWeather("Sydney");
	}

	public static async Task GetWeather(string Location)
	{
		var json = await WeatherApi.weatherApiClient.GetStringAsync($"{Location}&aqi=no");
	
	}
}