namespace MiApp.Views;

public partial class CalcularIMCPage : ContentPage
{
	public CalcularIMCPage()
	{
		InitializeComponent();
	}

    private void CalcularIMC(object sender, EventArgs e)
    {
        // Reiniciar errores
        ErrorPeso.IsVisible = false;
        ErrorAltura.IsVisible = false;
        ErrorSexo.IsVisible = false;
        TarjetaResultado.IsVisible = false;

        // Validar entradas
        bool pesoValido = double.TryParse(EntradaPeso.Text, out double peso);
        bool alturaValida = double.TryParse(EntradaAltura.Text, out double altura);
        bool sexoSeleccionado = SelectorSexo.SelectedIndex >= 0;

        if (!sexoSeleccionado)
        {
            ErrorSexo.Text = "Selecciona tu sexo.";
            ErrorSexo.IsVisible = true;
        }

        if (!pesoValido || peso <= 0)
        {
            ErrorPeso.Text = "Introduce un peso v�lido.";
            ErrorPeso.IsVisible = true;
        }

        if (!alturaValida || altura <= 0)
        {
            ErrorAltura.Text = "Introduce una altura v�lida.";
            ErrorAltura.IsVisible = true;
        }

        if (!pesoValido || !alturaValida || !sexoSeleccionado)
            return;

        // C�lculo de IMC
        double imc = peso / (altura * altura);
        string categoria = ObtenerCategoriaIMC(imc);
        Color colorFondo = ObtenerColorCategoria(categoria);

        // Mostrar resultados
        EtiquetaIMC.Text = $"IMC: {imc:F2}";
        EtiquetaCategoria.Text = $"Clasificaci�n: {categoria}";
        EtiquetaInfo.Text = "Seg�n la OMS, el rango normal est� entre 18.5 y 24.9";
        TarjetaResultado.BackgroundColor = colorFondo;
        TarjetaResultado.IsVisible = true;
    }

    private string ObtenerCategoriaIMC(double imc)
    {
        // Criterios de la Organizaci�n Mundial de la Salud
        if (imc < 18.5)
            return "Bajo peso";
        else if (imc < 25)
            return "Normal";
        else if (imc < 30)
            return "Sobrepeso";
        else
            return "Obesidad";
    }

    private Color ObtenerColorCategoria(string categoria)
    {
        return categoria switch
        {
            "Bajo peso" => Color.FromArgb("#FFA726"),     // Naranja
            "Normal" => Color.FromArgb("#66BB6A"),        // Verde
            "Sobrepeso" => Color.FromArgb("#FFCA28"),     // Amarillo
            "Obesidad" => Color.FromArgb("#EF5350"),      // Rojo
            _ => Colors.Gray
        };
    }
}