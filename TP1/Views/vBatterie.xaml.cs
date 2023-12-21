namespace TP1.Views;

public partial class vBatterie : ContentPage
{
	public vBatterie()
	{
		InitializeComponent();

        Battery.Default.BatteryInfoChanged += Battery_InfoChanged;
        Battery.Default.EnergySaverStatusChanged += Battery_ModeEcoChanger;

    }

	private string GetPowerSourceType()
    {
        switch (Battery.PowerSource)
        {
            case BatteryPowerSource.AC:
                return "AC 220V";
            case BatteryPowerSource.Usb:
                return "Câble USB";
            case BatteryPowerSource.Wireless:
                return "Chargeur sans fil";
            case BatteryPowerSource.Battery:
                return "Sur batterie";
            default:
                return "Inconnu";
        }
    }

    private void Afficher_Clicked(object sender, EventArgs e)
    {
        var typeSource = GetPowerSourceType();
        LabelInfo.Text = typeSource.ToString();
    }

    private void Battery_InfoChanged(object sender, BatteryInfoChangedEventArgs e)
    {
        LabelInfoCharge.Text = "Niveau de charge : " + (e.ChargeLevel *100) + "%";
        switch (e.State)
        {
            case BatteryState.Charging:
                LabelInfoEtat.Text = "Batterie en charge";
                break;
            case BatteryState.Discharging:
                LabelInfoEtat.Text = "Batterie en décharge";
                break;
            case BatteryState.NotCharging:
                LabelInfoEtat.Text = "Batterie non en charge";
                break;
            case BatteryState.Full:
                LabelInfoEtat.Text = "Batterie pleine";
                break;
            default:
                LabelInfoEtat.Text = "État de la batterie inconnu";
                break;
        }
    }

    private async void Battery_ModeEcoChanger(object sender, EnergySaverStatusChangedEventArgs e)
    {
        if (Battery.Default.EnergySaverStatus == EnergySaverStatus.On)
        {
            await DisplayAlert("Alert", "Mode economie d'energie active", "OK");
        }
        else
        {
            await DisplayAlert("Alert", "Mode economie d'energie arrete", "OK");
        }
    }

}