﻿using Microsoft.Extensions.Logging;
using ShopApp.DataAccess;
using ShopApp.Services;
using ShopApp.ViewModels;
using ShopApp.Views;

namespace ShopApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<INavegacionService, NavegacionService>();
            builder.Services.AddSingleton<CompraService>();
            builder.Services.AddSingleton<IDatabaseRutaService, DatabaseRutaService>();
            builder.Services.AddSingleton<SecurityService>();

            builder.Services.AddTransient<HelpSupportViewModel>();
            builder.Services.AddTransient<HelpSupportPage>();
            builder.Services.AddTransient<HelpSupportDetailViewModel>();
            builder.Services.AddTransient<HelpSupportDetailPage>();
            builder.Services.AddTransient<ClientsViewModel>();
            builder.Services.AddTransient<ClientsPage>();
            builder.Services.AddTransient<ProductsViewModel>();
            builder.Services.AddTransient<ProductsPage>();
            builder.Services.AddTransient<ResumenViewModel>();
            builder.Services.AddTransient<ResumenPage>();
            builder.Services.AddTransient<ProductDetailsViewModel>();
            builder.Services.AddTransient<ProductDetailPage>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<LoginPage>(); 

            builder.Services.AddSingleton(Connectivity.Current);
            builder.Services.AddSingleton<HttpClient>();

            builder.Services.AddDbContext<ShopOutDbContext>();

            var dbContext = new ShopDbContext();
            dbContext.Database.EnsureCreated();
            dbContext.Dispose();

            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(HelpSupportDetailPage), typeof(HelpSupportDetailPage));



#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}