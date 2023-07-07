namespace Cyclone;
using Newtonsoft.Json;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		//WeatherApi.InitaliseClient();
		//GetWeather("Sydney");
	}

	public async void GetWeather(string Location)
	{
		string json = await WeatherApi.client.GetStringAsync($"https://api.weatherapi.com/v1/current.json?key=APIKEYHERE&q={Location}&aqi=no");
        WeatherModel weather = JsonConvert.DeserializeObject<WeatherModel>(json);
        weatherCity.Text = $"{weather.location.name}";
        weatherRegionAndCountry.Text = $"{weather.location.region}, {weather.location.country}";
		weatherConditionIcon.Source = ImageSource.FromUri(new Uri(weather.current.condition.icon));
        weatherTemp.Text = $"{weather.current.temp_c}ºC";
		weatherConditionText.Text = $"{weather.current.condition.text}";
	}
}