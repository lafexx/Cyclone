namespace Cyclone;
using Newtonsoft.Json;
using Cyclone.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

		// Initialising the Client and Making the Call
		WeatherApi.InitaliseClient();
		GetWeather("Sydney");
	}

	public async void GetWeather(string Location)
	{
		WeatherModel weather = null;

		if (WeatherApi.weather == null)
        {
            try
            {
                // Fetching the json data and deserialising it into a WeatherModel
                string json = await WeatherApi.client.GetStringAsync($"https://api.weatherapi.com/v1/current.json?key=APIKEYHERE&q={Location}&aqi=no");
                weather = JsonConvert.DeserializeObject<WeatherModel>(json);
                WeatherApi.weather = weather;
            }
            catch
            {
                Console.WriteLine("Invalid search query (Status Code: 400 [Bad Request])");
            }
        }
        else
        {
            weather = WeatherApi.weather;
        }

        if (weather == null)
            return;

        //weatherConditionIcon.Uri = new Uri(weather.current.condition.icon);

        #region Setting Weather Information
        // Setting the basic weather information
        weatherCity.Text = $"{weather.location.name}";
        weatherRegionAndCountry.Text = $"{weather.location.region}, {weather.location.country}";
        weatherTemp.Text = $"{weather.current.temp_c}ºC";
		weatherConditionText.Text = $"{weather.current.condition.text}";
        #endregion 
    }

    public void SearchLocation(System.Object sender, System.EventArgs e)
    {
		// Get the text input
		string searchQuery = locationSearchBar.Text;
		// Get the weather
		GetWeather(searchQuery);
    }

    void RedirectToAdvanced(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new AdvancedPage());
    }
}