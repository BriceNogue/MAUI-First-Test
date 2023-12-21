namespace TP1.Views;

public partial class vGeo : ContentPage
{
    private CancellationTokenSource _cancelTokenSource;
    private bool _isCheckingLocation;

    public vGeo()
	{
		InitializeComponent();
	}

    public async Task GetCurentLocation()
    {
        await Task.Run(() =>
        {
            try
            {
                _isCheckingLocation = true;
                GeolocationRequest geolocationRequest = new GeolocationRequest(GeolocationAccuracy.Medium, TimeSpan.FromSeconds(10));
                _cancelTokenSource = new CancellationTokenSource();
                var location = Geolocation.Default.GetLocationAsync(geolocationRequest, _cancelTokenSource.Token);

                if (location != null)
                {
                    LabelLongitude.Text = "Longitude "+ location.Result.Longitude.ToString();
                    LabelLatitude.Text = "Latitude "+ location.Result.Latitude.ToString();
                    LabelAltitude.Text = "Altitude "+ location.Result.Altitude.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                _isCheckingLocation = false;
            }
        });
    }

    public async void Get_Localisation(object sender, EventArgs e)
    {
        await GetCurentLocation();
    }

    public void CancelLocation(object sender, EventArgs e)
    {
        if (_isCheckingLocation && _cancelTokenSource != null && _cancelTokenSource.IsCancellationRequested == false)
            _cancelTokenSource.Cancel();
    }

}