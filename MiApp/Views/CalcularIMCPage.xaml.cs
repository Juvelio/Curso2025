namespace MiApp.Views;

public partial class CalcularIMCPage : ContentPage
{
	public CalcularIMCPage()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {

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
}