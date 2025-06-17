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
                await Browser.OpenAsync("https://denuncias.policia.gob.pe/xyz/Login.aspx");
                break;
            default:
                await DisplayAlert("Error", "Sistema no reconocido", "OK");
                break;
        }   
    }    
}