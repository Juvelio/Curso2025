namespace MiApp.Views;

public partial class InicioPage : ContentPage
{
	public InicioPage()
	{
		InitializeComponent();
	}

    private async void btnRepositorio_Clicked(object sender, EventArgs e)
    {
		await Browser.OpenAsync("https://github.com/Juvelio/Curso2025");
    }
}