using CommunityToolkit.Mvvm.ComponentModel;
using MiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.ViewModels
{
    public partial class CiudadanosViewModel : ObservableObject
    {
        private readonly CiudadanoService _ciudadanoService;

        public CiudadanosViewModel(CiudadanoService ciudadanoService)
        {
            _ciudadanoService = ciudadanoService;
        }
    }
}
