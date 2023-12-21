using System.Text;

namespace TP1.Views
{
    public partial class vPhone : ContentPage
    {
        public vPhone()
        {
            InitializeComponent();
            //Phone_Info();
            Routing.RegisterRoute(nameof(vEcran), typeof(vEcran));
            Routing.RegisterRoute(nameof(vBatterie), typeof(vBatterie));
        }

        //Methode permetant l'appel d'une methode au demarrage de la fenetre.
        protected override void OnAppearing()
        {
            base.OnAppearing();

            Phone_Info();
        }

        private void Phone_Info()
        {
            StringBuilder stringBuilder = new StringBuilder();
            string idiom = Get_Idiom();

            stringBuilder.AppendLine
            (@$"
                Modèle: {DeviceInfo.Model} 
                Fabricant: {DeviceInfo.Manufacturer}
                Nom: {DeviceInfo.Name}
                Version: {DeviceInfo.VersionString}
                Plateforme: {DeviceInfo.Platform}
                Environnement: {idiom}
            ");

            string finalString = stringBuilder.ToString();

            lbPhoneInfo.Text = finalString;

        }

        private string Get_Idiom()
        {
            DeviceIdiom deviceIdiom = DeviceInfo.Current.Idiom;

            if (deviceIdiom == DeviceIdiom.Phone)
            {
                return "Telephone";
            } else if(deviceIdiom == DeviceIdiom.Desktop)
            {
                return "PC";
            }
            else if(deviceIdiom == DeviceIdiom.Tablet)
            {
                return "Tablette";
            }
            else
            {
                return "Peripherique non reconnu";
            }
        }

        private async void Ecran_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(vEcran));
        }

        private async void Batterie_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(vBatterie));
        }

    }
}