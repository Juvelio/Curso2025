namespace MiApp.Views;

public partial class SistemasPage : ContentPage
{
    public SistemasPage()
    {
        InitializeComponent();
    }

    private async void Sistema_Clicked(object sender, EventArgs e)
    {
        var sistema = (sender as Button)?.Text;

        switch (sistema)
        {
            case "SIDPOL":
                await Browser.OpenAsync("https://denuncias.policia.gob.pe/sidpol/Login.aspx");
                break;
            case "SIRDIC":
                await Browser.OpenAsync("https://denuncias.policia.gob.pe/sirdic/Login.aspx");
                break;
            case "SIEPOL":
                await Browser.OpenAsync("https://siepol.policia.gob.pe/Login.aspx");
                break;
            case "SERPOL":
                await Browser.OpenAsync("https://serpol.policia.gob.pe/serpol/login");
                break;
            case "CORREO PNP":
                await Browser.OpenAsync("https://correo.policia.gob.pe/");
                break;
            case "SIGCP":
                await Browser.OpenAsync("https://sigcp.policia.gob.pe/");
                break;
            case "MPD PNP":
                await Browser.OpenAsync("https://mpd.policia.gob.pe/login");
                break;
            case "LICENCIAS":
                await Browser.OpenAsync("https://denuncias.pnp.gob.pe/licencias/");
                break;
            default:
                await DisplayAlert("Error", "Sistema no reconocido", "OK");
                break;
        }
    }
}