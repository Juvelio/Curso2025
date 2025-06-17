namespace MiApp.Views;

public partial class CiudadanosPage : ContentPage
{
    public CiudadanosPage()
    {
        InitializeComponent();
    }

    public double Resultado { get; set; }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        try
        {
            var frame = sender as Grid;
            if (frame != null)
            {
                CambiarColorTemporalmente(frame);
            }

            string numero = ProcesarEntrada(e.Parameter.ToString());
            if (!string.IsNullOrEmpty(numero))
            {
                ActualizarOperacion(numero);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public bool cargando { get; set; }
    private async void CambiarColorTemporalmente(Grid frame)
    {
        if (cargando)
            return;

        cargando = true;
        var color = frame.BackgroundColor;
        frame.Opacity = 0.1;
        frame.BackgroundColor = Color.FromArgb("#000000");
        await Task.Delay(250); // Espera 250 milisegundos
        frame.Opacity = 1;
        frame.BackgroundColor = color;
        cargando = false;
    }


    private string ProcesarEntrada(string numero)
    {
        txtOperacion.IsVisible = true;
        txtResultado.FontSize = 20;

        switch (numero)
        {
            case "13":
                return "/";
            case "14":
                return "X";
            case "15":
                return "-";
            case "16":
                return "+";
            case "20":
                EliminarUltimoCaracter();
                return string.Empty;
            case "17":
                RealizarCalculoFinal();
                return string.Empty;
            case "10":
                LimpiarOperacion();
                return string.Empty;
            case "18":
                //Shell.Current.GoToAsync($"{nameof(CientificaPage)}");
                return string.Empty;
            default:
                return numero;
        }
    }

    private void ActualizarOperacion(string numero)
    {
        txtOperacion.Text += numero;
        Calcular(txtOperacion.Text);
    }

    private void EliminarUltimoCaracter()
    {
        if (txtOperacion.Text.Length > 0)
        {
            txtOperacion.Text = txtOperacion.Text.Substring(0, txtOperacion.Text.Length - 1);
        }
    }

    private void RealizarCalculoFinal()
    {
        txtResultado.FontSize = 60;
        txtOperacion.IsVisible = false;
        Calcular(txtOperacion.Text);
        txtOperacion.Text = string.Empty;
    }

    private void LimpiarOperacion()
    {
        txtOperacion.Text = string.Empty;
        txtResultado.Text = string.Empty;
    }

    private void Calcular(string operacion)
    {
        try
        {
            double resultado = EvaluarExpresion(operacion);
            txtResultado.Text = resultado.ToString();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al evaluar la expresión: " + ex.Message);
            txtResultado.Text = string.Empty;
        }
    }

    public static double EvaluarExpresion(string expresion)
    {
        try
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expresion.Replace('X', '*'), ""));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al evaluar la expresión: " + ex.Message);
            return 0;
        }
    }
}