namespace MiApp.Views;

public partial class ControlesPage : ContentPage
{
    public ControlesPage()
    {
        InitializeComponent();
    }

    private async void btnRepositorio_Clicked(object sender, EventArgs e)
    {
        await Browser.OpenAsync("https://github.com/Juvelio/Curso2025");
    }
}