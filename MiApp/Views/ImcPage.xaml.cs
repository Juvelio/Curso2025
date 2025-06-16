namespace MiApp.Views;

public partial class ImcPage : ContentPage
{
	public ImcPage()
	{
		InitializeComponent();
	}

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
		await Shell.Current.GoToAsync(nameof(CalcularIMCPage));
    }
}