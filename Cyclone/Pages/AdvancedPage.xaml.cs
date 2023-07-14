namespace Cyclone.Pages;

public partial class AdvancedPage : ContentPage
{
	public AdvancedPage()
	{
		InitializeComponent();
	}

    void RedirectToHome(System.Object sender, System.EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }
}