using MiApp.ViewModels;

namespace MiApp.Views;

public partial class CiudadanosPage : ContentPage
{
	public CiudadanosPage(CiudadanosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}