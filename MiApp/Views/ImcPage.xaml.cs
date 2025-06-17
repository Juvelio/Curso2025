namespace MiApp.Views;

public partial class ImcPage : ContentPage
{
    public ImcPage()
    {
        InitializeComponent();
    }

    private async void btnSiguiente_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text))
            return;

        Preferences.Set("MiNombre", txtNombre.Text);
        await Shell.Current.GoToAsync(nameof(CalcularIMCPage));
    }
}