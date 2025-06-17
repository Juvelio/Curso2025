namespace MiApp.Views;

public partial class CalcularIMCPage : ContentPage
{
    public CalcularIMCPage()
    {
        InitializeComponent();

       var Nombre =  Preferences.Get("MiNombre","");
        lblNombre.Text = $"Hola, {Nombre}";
    }

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        //Reiniciar errores
        ErrorPeso.IsVisible = false;
        ErrorTalla.IsVisible = false;
        TarjetaResultado.IsVisible = false;

        //Validaciones de campos
        bool pesoValido = double.TryParse(txtPeso.Text, out double peso);
        bool tallaValida = double.TryParse(txtTalla.Text, out double talla);

        if (!pesoValido || peso <= 0)
        {
            ErrorPeso.IsVisible = true;
            ErrorPeso.Text = "Ingrese un peso válido.";
        }

        if (!tallaValida || talla <= 0)
        {
            ErrorTalla.IsVisible = true;
            ErrorTalla.Text = "Ingrese una talla válida.";
        }

        if (!pesoValido || !tallaValida)
            return; //Si hay errores, no continuar

        //Calcular IMC
        double imc = peso / (talla * talla);
        string categoria = ObtenerCategoriaIMC(imc);
        Color colorCategoria = ObtenerColorCategoriaIMC(categoria);

        //Mostrar resultado
        EtiquetaIMC.Text = $"Tu IMC es: {imc:F2}";
        EtiquetaCategoria.Text = $"Categoria : {categoria}";
        EtiquetaInfo.Text = "Segun la OMS, el rango normal está entre 18.5 y 24.9";
        TarjetaResultado.Background = colorCategoria;
        TarjetaResultado.IsVisible = true;
    }

    private string ObtenerCategoriaIMC(double imc)
    {
        //Criterios de la Organizacion Mundial de la Salud (OMS)
        if (imc < 18.5)
            return "Bajo peso";
        else if (imc >= 18.5 && imc < 24.9)
            return "Peso normal";
        else if (imc >= 25 && imc < 29.9)
            return "Sobrepeso";
        else
            return "Obesidad";
    }

    //private Color ObtenerColorCategoriaIMC(string categoria)
    //{
    //    return categoria switch
    //    {
    //        "Bajo peso" => Colors.Blue,
    //        "Peso normal" => Colors.Green,
    //        "Sobrepeso" => Colors.Yellow,
    //        "Obesidad" => Colors.Red,
    //        _ => Colors.Gray
    //    };
    //}

    private Color ObtenerColorCategoriaIMC(string categoria)
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