namespace TP1
{
	public partial class APropos : ContentPage
    {
	    public APropos()
	    {
		    InitializeComponent();
	    }

        private async void APropos_Clicked(object sender, EventArgs e)
        {
            // Navigate to the specified URL in the system browser.
            await Launcher.Default.OpenAsync("https://www.3il-ingenieurs.fr/");
        }
    }
}