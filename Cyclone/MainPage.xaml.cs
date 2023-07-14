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

		try
		{
            // Fetching the json data and deserialising it into a WeatherModel
            string json = await WeatherApi.client.GetStringAsync($"https://api.weatherapi.com/v1/current.json?key=APIKEYHERE&q={Location}&aqi=no");
            weather = JsonConvert.DeserializeObject<WeatherModel>(json);
        }
		catch
		{
			Console.WriteLine("Invalid search query (Status Code: 400 [Bad Request])");
		}

        if (weather == null)
            return;

        weatherConditionIcon.Uri = new Uri(weather.current.condition.icon);

        #region Setting Weather Information
        // Setting the basic weather information
        weatherCity.Text = $"{weather.location.name}";
        weatherRegionAndCountry.Text = $"{weather.location.region}, {weather.location.country}";
        weatherTemp.Text = $"{weather.current.temp_c}ºC";
		weatherConditionText.Text = $"{weather.current.condition.text}";

        /*// Setting the advanced weather information
        weatherAirPressure.Text = $"Air Pressure: {weather.current.pressure_in}";
        weatherWindSpeed.Text = $"Wind Speed: {weather.current.wind_kph}km/h";
        weatherWindDegree.Text = $"Wind Degree: {weather.current.wind_degree}º";
        weatherWindDirection.Text = $"Wind Direction: {weather.current.wind_dir}";
        weatherPrecip.Text = $"Precipitation: {weather.current.precip_mm}mm";
        weatherHumidity.Text = $"Humidity: {weather.current.humidity}";
        weatherUV.Text = $"UV: {weather.current.uv}";
        weatherVisibility.Text = $"Visibility: {weather.current.vis_km}km";*/
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


/*
 
 Advanced Information and Search Bar Grid -->                     
                <Grid Grid.Row="0" Grid.ColumnSpan="3" RowDefinitions="Auto" ColumnDefinitions="*, *">
                    <!-- Advanced Info Left side -->
                    <StackLayout Grid.Row="0" Grid.ColumnSpan="2">
                        <Line StrokeLineCap="Round" Stroke="#242424" X2="350" HorizontalOptions="Center"/>
                        <Label x:Name="weatherWindSpeed" Text="Wind Speed: 10km/h" TextColor="LightGray" FontSize="15" HorizontalOptions="Start" Padding="0,15,0,0"/>
                        <Label x:Name="weatherWindDegree" Text="Wind Degree: 21.5º" TextColor="LightGray" FontSize="15" HorizontalOptions="Start"/>
                        <Label x:Name="weatherWindDirection" Text="Wind Direction: NWE" TextColor="LightGray" FontSize="15" HorizontalOptions="Start"/>
                        <Label x:Name="weatherUV" Text="UV: 0.2" TextColor="LightGray" FontSize="15" HorizontalOptions="Start" Padding="0,0,0,15"/>
                    </StackLayout>

                    <!-- Avanced Info Right side -->
                    <StackLayout Grid.Row="0" Grid.Column="2">
                        <Label x:Name="weatherAirPressure" Text="Air Pressure: 0.12in" TextColor="LightGray" FontSize="15" HorizontalOptions="End" Padding="0,15,0,0"/>
                        <Label x:Name="weatherPrecip" Text="Precipitation: 1mm" TextColor="LightGray" FontSize="15" HorizontalOptions="End"/>
                        <Label x:Name="weatherHumidity" Text="Humidity: 0.3" TextColor="LightGray" FontSize="15" HorizontalOptions="End"/>         
                        <Label x:Name="weatherVisibility" Text="Visibility: 10km" TextColor="LightGray" FontSize="15" HorizontalOptions="End" Padding="0,0,0,15"/>
                    </StackLayout>
                </Grid>
 
 
 */