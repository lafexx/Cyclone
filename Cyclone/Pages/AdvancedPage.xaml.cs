namespace Cyclone.Pages;

public partial class AdvancedPage : ContentPage
{
	public AdvancedPage()
	{
		InitializeComponent();
        SetInfo();
	}

    private void SetInfo()
    {
        WeatherModel weather = WeatherApi.weather;

        // Setting the advanced weather information
        weatherAirPressure.Text = $"Air Pressure: {weather.current.pressure_in}";
        weatherWindSpeed.Text = $"Wind Speed: {weather.current.wind_kph}km/h";
        weatherWindDegree.Text = $"Wind Degree: {weather.current.wind_degree}º";
        weatherWindDirection.Text = $"Wind Direction: {weather.current.wind_dir}";
        weatherPrecip.Text = $"Precipitation: {weather.current.precip_mm}mm";
        weatherHumidity.Text = $"Humidity: {weather.current.humidity}";
        weatherUV.Text = $"UV: {weather.current.uv}";
        weatherVisibility.Text = $"Visibility: {weather.current.vis_km}km";
    }

    void RedirectToHome(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}