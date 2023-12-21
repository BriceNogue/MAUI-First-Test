using System.Text;

namespace TP1.Views;

public partial class vEcran : ContentPage
{
	public vEcran()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        Info_Ecran();
    }

    private void Info_Ecran()
    {
        StringBuilder stringBuilder = new StringBuilder();

        var displayInfo = DeviceDisplay.MainDisplayInfo;

        stringBuilder.AppendLine
        (@$"
            Resolution: {displayInfo.Width} X {displayInfo.Height}
            Densité: {displayInfo.Density}
            Orientation: {displayInfo.Orientation}
            Rotation: {displayInfo.Rotation}
            Vitesse de refraichissement: {displayInfo.RefreshRate}
        ");

        string finalString = stringBuilder.ToString();

        lbInfoEcran.Text = finalString;

    }
}