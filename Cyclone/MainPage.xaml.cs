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

    /// <summary>
    /// Fetches the weather data from the API, deserializes it to a class and updates the info on screen.
    /// </summary>
    /// <param name="Location"></param>
    /// <param name="force"></param>
	public async void GetWeather(string Location, bool force = false)
	{
		WeatherModel weather = null;

		if (WeatherApi.weather == null || force)
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

        // TODO: Bugged, wont show weather condition icon 
        //weatherConditionIcon.Uri = new Uri(weather.current.condition.icon);

        #region Setting Weather Information
        // Setting the basic weather information
        weatherCity.Text = $"{weather.location.name}";
        weatherRegionAndCountry.Text = $"{weather.location.region}, {weather.location.country}";
        weatherTemp.Text = $"{weather.current.temp_c}ºC";
		weatherConditionText.Text = $"{weather.current.condition.text}";
        #endregion 
    }

    /// <summary>
    /// Gets the weather at the location specified in the search bar
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SearchLocation(System.Object sender, System.EventArgs e)
    {
		// Get the text input
		string searchQuery = locationSearchBar.Text;
		// Get the weather
		GetWeather(searchQuery, true);
    }

    /// <summary>
    /// Changes to the advanced weather information page
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void RedirectToAdvanced(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new AdvancedPage());
    }
}