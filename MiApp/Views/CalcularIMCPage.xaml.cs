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
            ErrorPeso.Text = "Introduce un peso válido.";
            ErrorPeso.IsVisible = true;
        }

        if (!alturaValida || altura <= 0)
        {
            ErrorAltura.Text = "Introduce una altura válida.";
            ErrorAltura.IsVisible = true;
        }

        if (!pesoValido || !alturaValida || !sexoSeleccionado)
            return;

        // Cálculo de IMC
        double imc = peso / (altura * altura);
        string categoria = ObtenerCategoriaIMC(imc);
        Color colorFondo = ObtenerColorCategoria(categoria);

        // Mostrar resultados
        EtiquetaIMC.Text = $"IMC: {imc:F2}";
        EtiquetaCategoria.Text = $"Clasificación: {categoria}";
        EtiquetaInfo.Text = "Según la OMS, el rango normal está entre 18.5 y 24.9";
        TarjetaResultado.BackgroundColor = colorFondo;
        TarjetaResultado.IsVisible = true;
    }

    private string ObtenerCategoriaIMC(double imc)
    {
        // Criterios de la Organización Mundial de la Salud
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