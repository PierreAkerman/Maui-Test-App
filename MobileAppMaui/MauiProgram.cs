﻿using Microsoft.AspNetCore.Components.WebView.Maui;
using MobileAppMaui.Data;
using MobileAppMaui.Services;
using System.Net;

namespace MobileAppMaui
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
                });

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif
            builder.Services.AddSingleton<IElevatorService, ElevatorService>();
            builder.Services.AddSingleton<WeatherForecastService>();

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            return builder.Build();
        }
    }
}