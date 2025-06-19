using MiApp.ViewModels;

namespace MiApp.Views;

public partial class CiudadanosPage : ContentPage
{
    private CiudadanosViewModel _viewModel;

    public CiudadanosPage(CiudadanosViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
         _viewModel.OnAppearing();
    }
}