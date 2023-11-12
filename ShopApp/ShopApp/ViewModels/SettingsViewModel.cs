using CommunityToolkit.Mvvm.Input;
using ShopApp.Services;
using ShopApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.ViewModels;

public partial class SettingsViewModel : ViewModelGlobal
{

    private readonly INavegacionService _navegacionService;

    [RelayCommand]
    async Task SalirSesion()
    {
        Preferences.Set("accesstoken", string.Empty);
        var uri = $"//{nameof(AboutPage)}";
        await _navegacionService.GoToAsync(uri);
    }

    public SettingsViewModel(INavegacionService navegacionService)
    {
        _navegacionService = navegacionService;
    }
}
