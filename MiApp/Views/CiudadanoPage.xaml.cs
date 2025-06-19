using MiApp.ViewModels;

namespace MiApp.Views;

public partial class CiudadanoPage : ContentPage
{
	public CiudadanoPage(CiudadanoViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
    }
}